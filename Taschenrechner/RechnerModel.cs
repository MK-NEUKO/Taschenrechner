using System;

namespace Taschenrechner
{
    public class RechnerModel
    {
        private double ersteZahl;
        private double zweiteZahl;
        private string operation;
        private double resultat;

        public RechnerModel()
        {
            ersteZahl = 0;
            zweiteZahl = 0;
            resultat = 0;
        }

        public double Resultat { get => resultat; }
        public string Operation
        {
            get { return operation; }
            set { operation = value; }            
        }
           
        public double ErsteZahl
        {
            get { return ersteZahl; }
            set 
            {
                if (value >= -10.0 && value <= 100.0)
                {
                    ersteZahl = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Wertebereich = -10 bis 100");
            }
        }

        public double ZweiteZahl
        {
            get { return zweiteZahl; }
            set
            {
                if (value >= -10.0 && value <= 100.0)
                {
                    zweiteZahl = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Wertebereich = -10 bis 100");           
            }
        }

        
        public void Berechne()
        {
            switch (Operation)
            {
                case "+":
                    resultat = Addiere(ErsteZahl, ZweiteZahl);
                    break;

                case "-":
                    resultat = Subtrahiere(ErsteZahl, ZweiteZahl);
                    break;

                case "/":
                    resultat = Dividiere(ErsteZahl, ZweiteZahl);
                    break;

                case "*":
                    resultat = Multipliziere(ErsteZahl, ZweiteZahl);
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
            if (divisor == 0) throw new DivideByZeroException("Unzulässige Division durch '0'.");

            double quotient = divident / divisor;
            return quotient;
        }
    }
}
