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

            string ersterSummand = HoleSummanden("Bitte den ersten Summanden eingeben: ");
            string zweiterSummand = HoleSummanden("Bitte den zweiten Summanden eingeben: ");

            // Wandle Text in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist
            double ersterSummandAlsZahl = Convert.ToDouble(ersterSummand);
            double zweiterSummandAlsZahl = Convert.ToDouble(zweiterSummand);

            // Berechnung ausführen
            double summe = Addiere(ersterSummandAlsZahl, zweiterSummandAlsZahl);

            // Ausgabe
            Console.WriteLine("Die Summe ist: {0}", summe);
            WarteAufBenutzerEingabe();
        }

        static string HoleSummanden(string ausgabeText)
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

        static void WarteAufBenutzerEingabe()
        {
            Console.Write("Zum Beenden bitte Return drücken!");
            Console.ReadLine();
        }
    }
}
