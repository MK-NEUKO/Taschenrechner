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
            
            RechnerModel model = new RechnerModel();
            ConsoleView view = new ConsoleView(model);
            string ersteZahlAlsString = view.HoleBenutzerEingabe("Bitte die erste Zahl eingeben: ");
            string zweiteZahlAlsString = view.HoleBenutzerEingabe("Bitte die zweite Zahl eingeben: ");
            string operation = view.HoleBenutzerEingabe("Bitte die entsprechende Rechenoperation wählen ( + | - | * | / ): ");

            // Wandle Text in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen
            
            model.Berechne(ersteZahl, zweiteZahl, operation);


            // Ausgabe
            view.GibResultatAus(operation);
            view.HoleBenutzerEingabe("Zum Beenden bitte Return drücken!");
        }


        
    }
}
