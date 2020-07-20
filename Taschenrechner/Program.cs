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
            string operation = HoleBenutzerEingabe("Bitte die entsprechende Rechenoperation wählen ( + | - | * | / ): ");

            // Wandle Text in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen
            RechnerModel model = new RechnerModel();
            double resultat = model.Berechne(ersteZahl, zweiteZahl, operation);


            // Ausgabe
            Ausgeben(resultat, operation);
            HoleBenutzerEingabe("Zum Beenden bitte Return drücken!");
        }


        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            string summand = Console.ReadLine();

            return summand;
        }

        

        static void Ausgeben(double resultat, string operation)
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
