using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public class RechnerModel
    {
        public bool FalscheEingabe { get; set; }
        public double Resultat { get; private set; }
        public string Operation { get; set; }

        private double _ersteZahl;

        public double ErsteZahl
        {
            get { return _ersteZahl; }
            set 
            {
                if (ErsteZahl <= 100 && ErsteZahl >= -10)
                {
                    _ersteZahl = value;
                }
                else
                    FalscheEingabe = true;
                 
            }
        }

        private double _zweiteZahl;

        public double ZweiteZahl
        {
            get { return _zweiteZahl; }
            set
            {
                if (ZweiteZahl > 100 || ZweiteZahl < -10)
                {
                    _zweiteZahl = value;
                }
                else
                    FalscheEingabe = true;

            }
        }


        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt";
            FalscheEingabe = false;
        }

        public void Berechne()
        {
            switch (Operation)
            {
                case "+":
                    Resultat = Addiere(ErsteZahl, ZweiteZahl);
                    break;

                case "-":
                    Resultat = Subtrahiere(ErsteZahl, ZweiteZahl);
                    break;

                case "/":
                    Resultat = Dividiere(ErsteZahl, ZweiteZahl);
                    break;

                case "*":
                    Resultat = Multipliziere(ErsteZahl, ZweiteZahl);
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
