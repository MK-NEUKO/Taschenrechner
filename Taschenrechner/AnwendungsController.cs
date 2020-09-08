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
            double ersteZahl = view.HohleZahlVomBenutzer();
            string operation = view.HoleOperatorVomBenutzer();
            double zweiteZahl = view.HohleZahlVomBenutzer();

            // Berechnung ausführen
            model.Berechne(ersteZahl, zweiteZahl, operation);

            // Ausgabe
            view.GibResultatAus(operation);
            view.WarteAufEndeDurchBenutzer();
        }
    }
}
