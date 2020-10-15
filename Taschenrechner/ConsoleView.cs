using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class ConsoleView
    {
        private readonly RechnerModel model;

        public event BeendenEventHandler Beenden;
        public event ZuruecksetzenEventHandler Zuruecksetzen;

        public ConsoleView(RechnerModel model)
        {
            this.model = model;
        }

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
            double zahl = 0;
            bool wiederholen;

            do
            {
                wiederholen = false;

                Console.Write("Zahl.....: ");
                eingabe = Console.ReadLine();

                eingabe = eingabe.ToUpper();
                if (eingabe == "ENDE")
                {
                    Beenden();
                    return 0;
                }
                else if (eingabe == "C")
                {
                    Zuruecksetzen();
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
                    Beenden();
                    return "";
                }
                else if (eingabe == "C")
                {
                    Zuruecksetzen();
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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
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
