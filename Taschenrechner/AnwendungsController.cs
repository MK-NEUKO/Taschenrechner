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
            while (!view.BenutzerWillBeenden)
            {
                view.ZeigeMenu();
                view.HohleEingabeVomBenutzer();
                if (view.KonsoleZurücksetzen)
                {
                    view.KonsoleZurücksetzen = false;
                    Console.Clear();
                    continue;
                }
                try
                {
                    model.Berechne();
                }
                catch (DivideByZeroException)
                {
                    view.HinweisDivideByZeroException();
                    continue;
                }
                view.GibResultatAus();
            }

            view.WarteAufEndeDurchBenutzer();
        }
    }
}
