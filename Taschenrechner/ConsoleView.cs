using System;

namespace Taschenrechner
{
    class ConsoleView
    {      
        private bool zahlHolen;
        private bool operatorHolen;
        private bool berechnen;
        private bool berechnungWiederholen;
        private bool zuruecksetzen;

        public ConsoleView()
        {
            zahlHolen = true;
            operatorHolen = true;
            berechnen = true;
            berechnungWiederholen = true;
            zuruecksetzen = false;
        }

        public bool ZahlHolen { get => zahlHolen; }
        public bool OperatorHolen { get => operatorHolen; }
        public bool Berechnen { get => berechnen; }
        public bool BerechnungWiederholen { get => berechnungWiederholen; }
        public bool Zuruecksetzen { get => zuruecksetzen; }

        public void ZeigeMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Beenden = (ENDE) | Berechnung Löschen = (C)");
            Console.WriteLine("Operatoren = (+ | - | * | / )              ");
            Console.ResetColor();
        }

        public void HinweisArgumentException()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Gültige Operatoren sind: (+ | - | * | / )");
            Console.WriteLine("Bitte versuchen Sie es erneut.           ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void HinweisDivideByZeroException()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Das Teilen durch '0' ist nicht definiert!");
            Console.WriteLine("Die Berechnung wird zurückgesetzt.       ");
            Console.WriteLine("Bitte beginnen Sie von vorn.             ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void KonsoleZuruecksetzen()
        {
            zahlHolen = true;
            operatorHolen = true;
            berechnen = true;
            berechnungWiederholen = true;
            zuruecksetzen = false;
            Console.Clear();
        }

        public void HinweisArgumentOutOfRangeException()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Ungültiger Wertebereich, dieser ist von -10 bis 100!");
            Console.WriteLine("Die Berechnung wird zurückgesetzt.                  ");
            Console.WriteLine("Bitte beginnen Sie von vorn.                        ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public double HohleZahlVomBenutzer()
        {
            string eingabe;
            double zahl;
            bool wiederholen;

            do
            {
                wiederholen = false;

                Console.Write("Zahl.....: ");
                eingabe = Console.ReadLine();

                eingabe = eingabe.ToUpper();
                if (eingabe == "ENDE")
                {
                    WarteAufEndeDurchBenutzer();
                    return 0;
                }
                else if (eingabe == "C")
                {
                    ZuruecksetzenVorbereiten();
                    return 0;
                }
                else if (!double.TryParse(eingabe, out zahl))
                {
                    wiederholen = true;
                    HinweisTryParseFehlgeschlagen();
                }
            } while (wiederholen);

            return zahl;
        }

        public string HohleOperatorVomBenutzer()
        {
            string eingabe;
            bool wiederholen;

            do
            {
                wiederholen = true;

                Console.Write("Operator.: ");
                eingabe = Console.ReadLine();

                eingabe = eingabe.ToUpper();
                if (eingabe == "ENDE")
                {
                    WarteAufEndeDurchBenutzer();
                    return "";
                }
                else if (eingabe == "C")
                {
                    ZuruecksetzenVorbereiten();
                    return "";
                }
                else if (eingabe == "+" || eingabe == "-" || eingabe == "/" || eingabe == "*")
                {                   
                    wiederholen = false;
                } 
                else
                    HinweisArgumentException();

            } while (wiederholen);

            return eingabe;
        }

        private void ZuruecksetzenVorbereiten()
        {
            zahlHolen = false;
            operatorHolen = false;
            berechnen = false;
            zuruecksetzen = true;
        }
       
        private void HinweisTryParseFehlgeschlagen()
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
        }

        public void WarteAufEndeDurchBenutzer()
        {
            zahlHolen = false;
            operatorHolen = false;
            berechnen = false;
            zuruecksetzen = false;
            berechnungWiederholen = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.Write("Zum Beenden bitte Return drücken!");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void GibResultatAus(RechnerModel model)
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
