using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class ConsoleView
    {
        public string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            string summand = Console.ReadLine();

            return summand;
        }


        public void GebeResultatAus(double resultat, string operation)
        {
            switch (operation)
            {
                case "+":
                    Console.WriteLine("Die Summe ist: {0}", resultat);
                    break;

                case "-":
                    Console.WriteLine("Die Differenz ist: {0}", resultat);
                    break;

                case "/":
                    Console.WriteLine("Der Quotient ist: {0}", resultat);
                    break;

                case "*":
                    Console.WriteLine("Das Produkt ist: {0}", resultat);
                    break;

                default:
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen!");
                    break;
            }
        }
    }
}
