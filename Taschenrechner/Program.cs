using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Titel: Addieren
            //Story: Als Benutzer möchte ich zwei Gleitkommazahlen eingeben, um die Summe berechnen zu lassen.

            Console.Write("Bitte den ersten Summanden eingeben: ");
            string ersterSummand = Console.ReadLine();
            Console.Write("Bitte den zweiten Summanden eingeben: ");
            string zweiterSummand = Console.ReadLine();

            // Eingabe in Zahl umwandeln
            float ersterSummandAlsZahl = Convert.ToSingle(ersterSummand);
            float zweiterSummandAlsZahl = Convert.ToSingle(zweiterSummand);

            // Berechnung
            Addiere(ersterSummandAlsZahl, zweiterSummandAlsZahl);

            // Ausgabe
            Console.WriteLine("Die Summe ist: {0}", summe);
            WarteAufBenutzerEingabe();
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
