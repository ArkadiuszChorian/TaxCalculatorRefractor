using TaxCalculator.Model;

namespace TaxCalculator.Printers
{
    internal interface IAgreementPrinter
    {
        void PrintFullInfo(Agreement agreement);
        void PrintSectionTytul(Agreement agreement);
        void PrintSectionSkladki(Agreement agreement);
        void PrintSectionPodatki(Agreement agreement);
        void PrintSectionWynagrodzenie(Agreement agreement);
    }
}
