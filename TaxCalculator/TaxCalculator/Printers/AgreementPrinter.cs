using System;
using TaxCalculator.Model;

namespace TaxCalculator.Printers
{
    public abstract class AgreementPrinter : IAgreementPrinter
    {
        protected const string TwoPointDecimalFormat = "#.##";

        public void PrintFullInfo(Agreement agreement)
        {
            PrintSectionTytul(agreement);
            PrintSectionSkladki(agreement);
            PrintSectionPodatki(agreement);
            PrintSectionWynagrodzenie(agreement);
        }

        public virtual void PrintSectionTytul(Agreement agreement) { }

        public virtual void PrintSectionSkladki(Agreement agreement)
        {
            Console.WriteLine("Podstawa wymiaru składek            :" + agreement.Podstawa);         
            Console.WriteLine("Składka na ubezpieczenie emerytalne :" + agreement.SkladkaEmerytalna.ToString(TwoPointDecimalFormat));
            Console.WriteLine("Składka na ubezpieczenie rentowe    :" + agreement.SkladkaRentowa.ToString(TwoPointDecimalFormat));
            Console.WriteLine("Składka na ubezpieczenie chorobowe  :" + agreement.UbezpieczenieChorobowe.ToString(TwoPointDecimalFormat));
            Console.WriteLine("Podstawa wymiaru składki na ubezpieczenie zdrowotne :" + agreement.PodstawaOpodatkowania);
            Console.WriteLine("Składka na ubezpieczenie zdrowotne: 9% = " + agreement.SkladkaZdrowotna1.ToString(TwoPointDecimalFormat) 
                + " 7,75% = " + agreement.SkladkaZdrowotna2.ToString(TwoPointDecimalFormat));
        }

        public virtual void PrintSectionPodatki(Agreement agreement) { }

        public virtual void PrintSectionWynagrodzenie(Agreement agreement)
        {
            Console.WriteLine("");
            Console.WriteLine("Pracownik otrzyma wynagrodzenie netto w wysokości = " + agreement.ObliczWynagrodzenie());
        }
    }
}
