using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class AnwendungsController
    {
        private RechnerModel model;
        private ConsoleView view;

        public AnwendungsController(RechnerModel model, ConsoleView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Ausfuehren()
        {
            string ersteZahlAlsString = view.HohleZahlVomBenutzer();
            string operation = view.HoleOperatorVomBenutzer();
            string zweiteZahlAlsString = view.HohleZahlVomBenutzer();


            // Wandle Text in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist
            double ersteZahl = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahl = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen

            model.Berechne(ersteZahl, zweiteZahl, operation);


            // Ausgabe
            view.GibResultatAus(operation);
            view.WarteAufEndeDurchBenutzer();
        }
    }
}
