using System;

namespace Taschenrechner
{
    public class RechnerModel
    {
        private double _ersteZahl;
        private double _zweiteZahl;
        private string _operation;

        public RechnerModel()
        {
            Resultat = 0;
            //Operation = "";
        }
       
        public double Resultat { get; private set; }
        public string Operation
        {
            get { return _operation; }
            set
            {
                if (value == "+" || value == "-" || value == "/" || value == "*")
                {
                    _operation = value;
                }
                else
                    throw new ArgumentException("Gültige Operatoren sind (+ | - | * | / )");
            }
        }
           
        public double ErsteZahl
        {
            get { return _ersteZahl; }
            set 
            {
                if (value >= -10.0 && value <= 100.0)
                {
                    _ersteZahl = value;
                }
                else
                    throw new ArgumentOutOfRangeException();
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
                }
                else
                    throw new ArgumentOutOfRangeException();           
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
            if (divisor == 0) throw new DivideByZeroException();

            double quotient = divident / divisor;
            return quotient;
        }
    }
}
