using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class RechnerModel
    {
        public double Resultat { get; private set; }
        public string Operation { get; private set; }

        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt";
        }

        public void Berechne(double ersteZahl, double zweiteZahl, string operation)
        {
            this.Operation = operation;
            switch (operation)
            {
                case "+":
                    Resultat = Addiere(ersteZahl, zweiteZahl);
                    break;

                case "-":
                    Resultat = Subtrahiere(ersteZahl, zweiteZahl);
                    break;

                case "/":
                    Resultat = Dividiere(ersteZahl, zweiteZahl);
                    break;

                case "*":
                    Resultat = Multipliziere(ersteZahl, zweiteZahl);
                    break;

                default:
                    Console.WriteLine("Du hast eine ungültige Auswahl der Operation getroffen!");
                    break;
            }
        }

        private double Subtrahiere(double minuend, double subtrahend)
        {
            double differenz = minuend - subtrahend;
            return differenz;
        }

        private double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;
            return summe;
        }

        private double Multipliziere(double ersterFaktor, double zweiterFaktor)
        {
            double produkt = ersterFaktor * zweiterFaktor;
            return produkt;
        }

        private double Dividiere(double divident, double divisor)
        {
            double quotient = divident / divisor;
            return quotient;
        }
    }
}
