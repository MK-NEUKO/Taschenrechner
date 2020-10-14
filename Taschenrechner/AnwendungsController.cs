﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
                        continue;
                    model.Operation = view.HohleOperatorVomBenutzer();
                    if (benutzerWillBeenden)
                        break;
                    if (benutzerWillZuruecksetzen)
                        continue;
                    model.ZweiteZahl = view.HohleZahlVomBenutzer();
                    if (benutzerWillBeenden)
                        break;
                    if (benutzerWillZuruecksetzen)
                        continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    view.HinweisArgumentOutOfRangeException();
                    continue;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
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
