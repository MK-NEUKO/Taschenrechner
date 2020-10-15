using System;

namespace Taschenrechner
{
    class AnwendungsController
    {
        private RechnerModel model;
        private ConsoleView view;

        private bool benutzerWillBeenden;
        private bool benutzerWillZuruecksetzen;

        public AnwendungsController(RechnerModel model, ConsoleView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Ausfuehren()
        {
            while (!benutzerWillBeenden)
            {
                view.ZeigeMenu();

                try
                {
                    model.ErsteZahl = view.HohleZahlVomBenutzer();
                    if (benutzerWillBeenden)
                        break;
                    if (benutzerWillZuruecksetzen)
                    {
                        benutzerWillZuruecksetzen = false;
                        continue;
                    }
 
                    model.Operation = view.HohleOperatorVomBenutzer();
                    if (benutzerWillBeenden)
                        break;
                    if (benutzerWillZuruecksetzen)
                    {
                        benutzerWillZuruecksetzen = false;
                        continue;
                    }

                    model.ZweiteZahl = view.HohleZahlVomBenutzer();
                    if (benutzerWillBeenden)
                        break;
                    if (benutzerWillZuruecksetzen)
                    {
                        benutzerWillZuruecksetzen = false;
                        continue;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    view.HinweisArgumentOutOfRangeException();
                    continue;
                }
                catch (ArgumentException)
                {
                    view.HinweisArgumentException();
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

        public void View_Beenden()
        {          
            benutzerWillBeenden = true;
        }

        public void View_Zuruecksetzen()
        {
            Console.Clear();
            benutzerWillZuruecksetzen = true;
        }
    }
}
