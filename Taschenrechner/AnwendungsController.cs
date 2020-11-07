using System;
using System.Runtime.CompilerServices;
using System.Security.Policy;

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
            do
            {
                view.ZeigeMenu();

                try
                {
                    if (view.ZahlHolen)
                        model.ErsteZahl = view.HohleZahlVomBenutzer();
                    if (view.OperatorHolen)
                        model.Operation = view.HohleOperatorVomBenutzer();
                    if (view.ZahlHolen)
                        model.ZweiteZahl = view.HohleZahlVomBenutzer();
                    if (view.Berechnen)
                    {
                        model.Berechne();
                        view.GibResultatAus(model);
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    view.HinweisArgumentOutOfRangeException();                  
                }                              
                catch (DivideByZeroException)
                {
                    view.HinweisDivideByZeroException();                   
                }

                if(view.Zuruecksetzen)
                    view.KonsoleZuruecksetzen();

            } while (view.BerechnungWiederholen);           
        }                      
    }
}
