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
                model.Berechne();
                view.GibResultatAus();
                while (!view.BenutzerWillBeenden)
                {
                    view.HohleWeitereEingabenVomBenutzer();
                    model.Berechne();
                    view.GibResultatAus();
                }
            }
           
            view.WarteAufEndeDurchBenutzer();
        }
    }
}
