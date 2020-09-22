using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class ConsoleView
    {
        private RechnerModel model;


        public ConsoleView(RechnerModel model)
        {
            this.model = model;
            BenutzerWillBeenden = false;
        }

        public bool BenutzerWillBeenden { get; private set; }
        

        public double HohleZahlVomBenutzer()
        {
            string eingabe;
            double zahl;
            Console.Write("Bitte eine Zahl für die Brechnung eingeben (FERTIG zum Beenden): ");
            eingabe = Console.ReadLine();

            if (eingabe == "FERTIG")
            {
                BenutzerWillBeenden = true;
                eingabe = "0,0";
            }

            while (!double.TryParse(eingabe, out zahl))
            {
                Console.WriteLine();
                Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben!");
                Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden.");
                Console.WriteLine("Der . fungiert als Trennzeichen an Tausenderstellen.");
                Console.WriteLine("Das , ist das Trennzeichen für die Nachkommastellen.");
                Console.WriteLine("Alle drei Sonderzeichen sind optional!");
                Console.WriteLine();
                Console.Write("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                eingabe = Console.ReadLine();
            }
            return zahl;
        }

        public void HohleWeitereEingabenVomBenutzer()
        {
            model.ErsteZahl = model.Resultat;
            model.Operation = HohleOperatorVomBenutzer();
            model.ZweiteZahl = HohleZahlVomBenutzer();
        }

        public void HohleEingabeVomBenutzer()
        {
            model.ErsteZahl = HohleZahlVomBenutzer();
            model.Operation = HohleOperatorVomBenutzer();
            model.ZweiteZahl = HohleZahlVomBenutzer();
        }

        private string HohleOperatorVomBenutzer()
        {
            Console.Write("Bitte die gewünschte Operation wählen ( + | - | * | / ): ");
            return Console.ReadLine();
        }

        public void WarteAufEndeDurchBenutzer()
        {
            Console.Write("Zum Beenden bitte Return drücken!");
            Console.ReadLine();
        }

        public void GibResultatAus()
        {
            switch (model.Operation)
            {
                case "+":
                    Console.WriteLine("Die Summe ist: {0}", model.Resultat);
                    break;

                case "-":
                    Console.WriteLine("Die Differenz ist: {0}", model.Resultat);
                    break;

                case "/":
                    Console.WriteLine("Der Quotient ist: {0}", model.Resultat);
                    break;

                case "*":
                    Console.WriteLine("Das Produkt ist: {0}", model.Resultat);
                    break;

                default:
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen!");
                    break;
            }
        }
    }
}
