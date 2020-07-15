using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        // METHODE DEFINIEREN (in 7 Schritten)
        // (optional) Modifizierer Definieren
        // Datentyp des Rückgabewertes definieren
        // Methodenname definieren
        // Runde Klammern an den Methodennamen anfügen
        // Überlegen welche Parameter benötigt werden (Optional diese definieren)
        // Geschweifte Klammern einfügen
        // Methode implementieren (Anweisungen in den Methodenrumpf schreiben)

        

        static void Main(string[] args)
        {
            //Titel: Addieren
            //Story: Als Benutzer möchte ich zwei Gleitkommazahlen eingeben, um die Summe berechnen zu lassen.

            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte die erste Zahl eingeben: ");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte die zweite Zahl eingeben: ");
            string operatíon = HoleBenutzerEingabe("Bitte die entsprechende Rechenoperation wählen ( + | - | * | / ): ");

            // Wandle Text in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen
            double resultat = 0;
            switch (operatíon)
            {
                case "+":
                    resultat = Addiere(ersteZahl, zweiteZahl);
                    Console.WriteLine("Die Summe ist: {0}", resultat);
                    break;

                case "-":
                    resultat = Subtrahieren(ersteZahl, zweiteZahl);
                    Console.WriteLine("Die Differenz ist: {0}", resultat);
                    break;

                case "/":
                    resultat = Dividieren(ersteZahl, zweiteZahl);
                    Console.WriteLine("Der Quotient ist: {0}", resultat);
                    break;

                case "*":
                    resultat = Multiplizieren(ersteZahl, zweiteZahl);
                    Console.WriteLine("Das Produkt ist: {0}", resultat);
                    break;

                default:
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen!");
                    break;
            }
          
            // Ausgabe
            HoleBenutzerEingabe("Zum Beenden bitte Return drücken!");
        }


        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            string summand = Console.ReadLine();

            return summand;
        }

        static double Subtrahieren(double minuend, double subtrahend)
        {
            double differenz = minuend - subtrahend;
            return differenz;
        }

        static double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;
            return summe;
        }

        static double Multiplizieren(double ersterFaktor, double zweiterFaktor)
        {
            double produkt = ersterFaktor * zweiterFaktor;
            return produkt;
        }

        static double Dividieren(double divident, double divisor)
        {
            double quotient = divident / divisor;
            return quotient;
        }
    }
}
