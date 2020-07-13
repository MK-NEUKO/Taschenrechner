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

            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte den ersten Summanden eingeben: ");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte den zweiten Summanden eingeben: ");
            string operatíon = HoleBenutzerEingabe("Bitte die entsprechende Rechenoperation wählen (+ / -): ");

            // Wandle Text in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen
            double resultat = 0;
            if (operatíon == "+")
            {
                resultat = Addiere(ersteZahl, zweiteZahl);
                Console.WriteLine("Die Summe ist: {0}", resultat);
            }
            else if (operatíon == "-")
            {
                resultat = Subtrahieren(ersteZahl, zweiteZahl);
                Console.WriteLine("Die Differenz ist: {0}", resultat);
            }
            else
            {
                Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen!");
            }
            

            // Ausgabe
            HoleBenutzerEingabe("Zum Beenden bitte Return drücken!");
        }

        static double Subtrahieren(double minuend, double subtrahend)
        {
            double differenz = minuend - subtrahend;
            return differenz;
        }

        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            string summand = Console.ReadLine();

            return summand;
        }

        static double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;
            return summe;
        }

    }
}
