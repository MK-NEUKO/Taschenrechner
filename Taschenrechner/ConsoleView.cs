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
            FalscheEingabeZahl = false;
            FalscheEingabeOperator = false;
        }

        public bool BenutzerWillBeenden { get; private set; }
        public bool FalscheEingabeZahl { get; private set; }
        public bool FalscheEingabeOperator { get; private set; }
        public bool ConsoleZurücksetzen { get; set; }
        
        public void ZeigeMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Beenden = (ENDE) | Berechnung Löschen = (C)");
            Console.WriteLine("Operatoren = (+ | - | * | / )              ");
            Console.ResetColor();
        }

        public void HohleEingabeVomBenutzer()
        {
            do
            {
                model.ErsteZahl = HohleZahlVomBenutzer();
            } while (FalscheEingabeZahl);
            if (ConsoleZurücksetzen)
                return;
            if (BenutzerWillBeenden)
                return;

            do
            {
                model.Operation = HohleOperatorVomBenutzer();
            } while (FalscheEingabeOperator);
            if (ConsoleZurücksetzen)
                return;
            if (BenutzerWillBeenden)
                return;

            do
            {
                model.ZweiteZahl = HohleZahlVomBenutzer();
            } while (FalscheEingabeZahl);
            if (ConsoleZurücksetzen)
                return;
            if (BenutzerWillBeenden)
                return;
        }

        public void HohleWeitereEingabenVomBenutzer()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Letztes Ergebnis = Erste Zahl!                 ");
            Console.WriteLine("Es geht weiter, mit der Eingabe des Operators! ");
            Console.ResetColor();
            Console.Write("Zahl.....: " + model.Resultat);
            Console.WriteLine();

            model.ErsteZahl = model.Resultat;

            do
            {
                model.Operation = HohleOperatorVomBenutzer();
            } while (FalscheEingabeOperator);
            if (ConsoleZurücksetzen)
                return;
            if (BenutzerWillBeenden)
                return;

            do
            {
                model.ZweiteZahl = HohleZahlVomBenutzer();
            } while (FalscheEingabeZahl);
            if (ConsoleZurücksetzen)
                return;
            if (BenutzerWillBeenden)
                return;
        }


        private double HohleZahlVomBenutzer()
        {
            string eingabe;
            Console.Write("Zahl.....: ");
            eingabe = Console.ReadLine();

            MenuAbfrage(eingabe);
            if (ConsoleZurücksetzen)
                return 0.0;
            if (BenutzerWillBeenden)
                return 0.0;
            return PruenfeAufGueltigeEingabeZahl(eingabe);
        }

        private string HohleOperatorVomBenutzer()
        {
            string eingabe;
            Console.Write("Operator.: ");
            eingabe = Console.ReadLine();

            MenuAbfrage(eingabe);
            if (ConsoleZurücksetzen)
                return "";
            if (BenutzerWillBeenden)
                return "";
            PruenfeAufGueltigeEingabeOperator(eingabe);

            return eingabe;
        }

        private void MenuAbfrage(string eingabe)
        {
            eingabe = eingabe.ToUpper();

            if (eingabe == "ENDE")
            {
                BenutzerWillBeenden = true;
                return;
            } 

            if (eingabe == "C")
            {
                ConsoleZurücksetzen = true;
                return;
            }
        }
   
        private double PruenfeAufGueltigeEingabeZahl(string eingabe)
        {
            double zahl;

            if (model.FalscheEingabe)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Die eingegebene Zahl muss zwischen -10,0 und 100,0 liegen!");
                Console.ResetColor();
                FalscheEingabeZahl = true;
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

        private void PruenfeAufGueltigeEingabeOperator(string eingabe)
        {
            if (eingabe != "+" && eingabe != "-" && eingabe != "/" && eingabe != "*")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Gültige Operatoren sind (+ | - | * | / )");
                Console.ResetColor();
                FalscheEingabeOperator = true;
            }
            else
                FalscheEingabeOperator = false;
        }

        public void WarteAufEndeDurchBenutzer()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("Zum Beenden bitte Return drücken!");
            Console.ResetColor();
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
            }
        }
    }
}
