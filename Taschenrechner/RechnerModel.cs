using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public class RechnerModel
    {
        private double _ersteZahl;
        private double _zweiteZahl;

        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt";
            FalscheEingabe = false;
        }

        public bool FalscheEingabe { get; private set; }
        public double Resultat { get; private set; }
        public string Operation { get; set; }
        public double ErsteZahl
        {
            get { return _ersteZahl; }
            set 
            {
                if (value >= -10.0 && value <= 100.0)
                {
                    _ersteZahl = value;
                    FalscheEingabe = false;
                }
                else
                    FalscheEingabe = true;
            }
        }

        public double ZweiteZahl
        {
            get { return _zweiteZahl; }
            set
            {
                if (value >= -10.0 && value <= 100.0)
                {
                    _zweiteZahl = value;
                    FalscheEingabe = false;
                }
                else
                    FalscheEingabe = true;            
            }
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
