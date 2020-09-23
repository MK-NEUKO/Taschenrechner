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
        
        public void ZeigeMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Beenden = (ENDE) | Berechnung Löschen = (C) | Aktuelle Zahl löschen = (CE)");
            Console.WriteLine("Operatoren = (+ | - | * | / )                                             ");
            Console.ResetColor();
        }
        public double HohleZahlVomBenutzer()
        {
            string eingabe;
            double zahl;
            Console.Write("Zahl.....: ");
            eingabe = Console.ReadLine();

            if (eingabe == "ENDE")
            {
                BenutzerWillBeenden = true;
                eingabe = "0,0";
            }

            while (!double.TryParse(eingabe, out zahl))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben!                                ");
                Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.- ");
                Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden.          ");
                Console.WriteLine("Der . fungiert als Trennzeichen an Tausenderstellen.                          ");
                Console.WriteLine("Das , ist das Trennzeichen für die Nachkommastellen.                          ");
                Console.WriteLine("Alle drei Sonderzeichen sind optional!                                        ");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Zahl.....: ");
                eingabe = Console.ReadLine();
            }
            return zahl;
        }

        private bool PruefeAufGueltigenWertebereich()
        {
            if (model.FalscheEingabe)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Die eingegebene Zahl muss zwischen -10,0 und 100,0 liegen!");
                Console.ResetColor();
                return true;
            }
            else
                return false;
        }

        public void HohleWeitereEingabenVomBenutzer()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Letztes Ergebnis = Erste Zahl!                 ");
            Console.WriteLine("Es geht weiter, mit der Eingabe des Operators! ");
            Console.ResetColor();

            model.ErsteZahl = model.Resultat;
            model.Operation = HohleOperatorVomBenutzer();

            do
            {
                model.ZweiteZahl = HohleZahlVomBenutzer();
            } while (PruefeAufGueltigenWertebereich());
        }

        public void HohleEingabeVomBenutzer()
        {
            do
            {
                model.ErsteZahl = HohleZahlVomBenutzer();
            } while (PruefeAufGueltigenWertebereich());

            model.Operation = HohleOperatorVomBenutzer();

            do
            {
                model.ZweiteZahl = HohleZahlVomBenutzer();
            } while (PruefeAufGueltigenWertebereich());
        }

        private string HohleOperatorVomBenutzer()
        {
            Console.Write("Operator.: ");
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
                    Console.WriteLine("Ergebnis.: " + model.Resultat + " = (" + model.ErsteZahl + ")+(" + model.ZweiteZahl + ")");
                    Console.WriteLine("-------------------------------------------------");
                    break;

                case "-":
                    Console.WriteLine("Ergebnis.: " + model.Resultat + " = (" + model.ErsteZahl + ")-(" + model.ZweiteZahl + ")");
                    Console.WriteLine("-------------------------------------------------");
                    break;

                case "/":
                    Console.WriteLine("Ergebnis.: " + model.Resultat + " = (" + model.ErsteZahl + ")/(" + model.ZweiteZahl + ")");
                    Console.WriteLine("-------------------------------------------------");
                    break;

                case "*":
                    Console.WriteLine("Ergebnis.: " + model.Resultat + " = (" + model.ErsteZahl + ")*(" + model.ZweiteZahl + ")");
                    Console.WriteLine("-------------------------------------------------");
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen!");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
