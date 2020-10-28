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
            while (true)
            {
                view.ZeigeMenu();

                try
                {                    
                    model.ErsteZahl = view.HohleZahlVomBenutzer();                   
                    model.Operation = view.HohleOperatorVomBenutzer();                   
                    model.ZweiteZahl = view.HohleZahlVomBenutzer();                  
                    model.Berechne();
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
                catch (DivideByZeroException)
                {
                    view.HinweisDivideByZeroException();
                    continue;
                }
                
                view.GibResultatAus();
            }
        }                

        public void View_Zuruecksetzen()
        {
            Console.Clear();            
            Ausfuehren();
        }
    }
}
