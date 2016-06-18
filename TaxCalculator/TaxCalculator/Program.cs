using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Configs;
using TaxCalculator.Model;
using TaxCalculator.Printers;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double podstawa;
            char typUmowy;
            AgreementConfig konfiguracja;
            AgreementPrinter printer;

            Console.WriteLine("Podaj kwote podstawy:");
            podstawa = double.Parse(Console.ReadLine());

            Console.WriteLine("Podaj typ umowy:");
            typUmowy = char.Parse(Console.ReadLine());

            if (typUmowy == 'P')
            {
                konfiguracja = new UmowaOPraceConfig();
                printer = new UmowaOPracePrinter();
            }
            else
            {
                konfiguracja = new UmowaZlecenieConfig();
                printer = new UmowaZleceniePrinter();
            }

            var umowa = new Agreement(podstawa, typUmowy, konfiguracja, printer);

            umowa.WyswietlInformacje();

            Console.Read();
        }
    }
}
