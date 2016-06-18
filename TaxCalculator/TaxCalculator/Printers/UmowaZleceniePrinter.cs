using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Model;

namespace TaxCalculator.Printers
{
    public class UmowaZleceniePrinter : AgreementPrinter
    {
        public override void PrintSectionTytul(Agreement agreement)
        {
            Console.WriteLine("UMOWA ZLECENIE");
        }

        public override void PrintSectionPodatki(Agreement agreement)
        {
            Console.WriteLine("Koszty uzyskania przychodu (stałe) " + agreement.KosztyUzyskania);
            Console.WriteLine("Podstawa opodatkowania " + agreement.PodstawaOpodatkowaniaZredukowana + " zaokrąglona " + agreement.PodstawaOpodatkowaniaZredukowanaZaokraglona);
            Console.WriteLine("Zaliczka na podatek dochodowy 18 % = " + agreement.ZaliczkaNaPodatekDochodowy);
            Console.WriteLine("Podatek potrącony = " + agreement.ZaliczkaNaPodatekDochodowy.ToString(TwoPointDecimalFormat));
            Console.WriteLine("Zaliczka do urzędu skarbowego = " + agreement.ZaliczkaDlaUs + " po zaokrągleniu = " + agreement.ZaliczkaDlaUsZaokraglona);
        }
    }
}
