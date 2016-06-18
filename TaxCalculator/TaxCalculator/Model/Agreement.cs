using System;
using TaxCalculator.Configs;
using TaxCalculator.Printers;

namespace TaxCalculator.Model
{
    public class Agreement
    {
        private readonly AgreementConfig _agreementConfig;
        private readonly AgreementPrinter _agreementPrinter;

        public double Podstawa { get; }
        public char TypUmowy { get; }
        public double SkladkaEmerytalna { get; set; }
        public double SkladkaRentowa { get; set; }
        public double UbezpieczenieChorobowe { get; set; }
        public double SkladkaZdrowotna1 { get; set; }
        public double SkladkaZdrowotna2 { get; set; }
        public double ZaliczkaNaPodatekDochodowy { get; }
        public double PotraconyPodatek => ZaliczkaNaPodatekDochodowy - _agreementConfig.KwotaZmiejszajaca;
        public double ZaliczkaDlaUs { get; }
        public double ZaliczkaDlaUsZaokraglona => Math.Round(ZaliczkaDlaUs);
        public double PodstawaOpodatkowania { get; }
        public double PodstawaOpodatkowaniaZredukowana => PodstawaOpodatkowania - KosztyUzyskania;
        public double PodstawaOpodatkowaniaZredukowanaZaokraglona => Math.Round(PodstawaOpodatkowania - KosztyUzyskania);

        public double KosztyUzyskania
        {
            get
            {
                if (TypUmowy == 'Z')
                {
                    return PodstawaOpodatkowania*20/100;
                }
                return _agreementConfig.KosztyUzyskania;
            }
        }

        //public static double KosztyUzyskania = 111.25;
        //public static double KwotaZmiejszajaca = 46.33;
        //public static double ProcentSkladkiEmerytalnej = 9.76;
        //public static double ProcentSkladkiRentowej = 1.5;
        //public static double ProcentUbezpieczeniaChorobowego = 2.45;
        //public static double ProcentSkladkiZdrowotnej1 = 9;
        //public static double ProcentSkladkiZdrowotnej2 = 7.75;
        //public static double ProcentPodatkuDochodowego = 18;

        public Agreement(double podstawa, char typUmowy, AgreementConfig agreementConfig, AgreementPrinter agreementPrinter)
        {
            _agreementConfig = agreementConfig;
            _agreementPrinter = agreementPrinter;
            Podstawa = podstawa;
            TypUmowy = typUmowy;
            ObliczSkladkiIUbezpieczenia();
            PodstawaOpodatkowania = ObliczPodstaweOpodatkowania();
            ZaliczkaNaPodatekDochodowy = ObliczPodatek();
            ZaliczkaDlaUs = ObliczZaliczkeDlaUs();                    
        }

        public void WyswietlInformacje()
        {
            _agreementPrinter.PrintFullInfo(this);
        }

        public double ObliczWynagrodzenie()
        {
            return Podstawa - (SkladkaEmerytalna + SkladkaRentowa + UbezpieczenieChorobowe + SkladkaZdrowotna1 + ZaliczkaDlaUs);
        }

        private double ObliczZaliczkeDlaUs()
        {
            return ZaliczkaNaPodatekDochodowy - SkladkaZdrowotna2 - _agreementConfig.KwotaZmiejszajaca;
        }

        private double ObliczPodatek()
        {
            return (PodstawaOpodatkowaniaZredukowanaZaokraglona * _agreementConfig.ProcentPodatkuDochodowego) / 100;
        }

        private double ObliczPodstaweOpodatkowania()
        {
            return (Podstawa - SkladkaEmerytalna - SkladkaRentowa - UbezpieczenieChorobowe);
        }

        private void ObliczSkladkiIUbezpieczenia()
        {
            SkladkaZdrowotna1 = (Podstawa * _agreementConfig.ProcentSkladkiZdrowotnej1) / 100;
            SkladkaZdrowotna2 = (Podstawa * _agreementConfig.ProcentSkladkiZdrowotnej2) / 100;
            SkladkaEmerytalna = (Podstawa * _agreementConfig.ProcentSkladkiEmerytalnej) / 100;
            SkladkaRentowa = (Podstawa * _agreementConfig.ProcentSkladkiRentowej) / 100;
            UbezpieczenieChorobowe = (Podstawa * _agreementConfig.ProcentUbezpieczeniaChorobowego) / 100;
        }
    }
}
