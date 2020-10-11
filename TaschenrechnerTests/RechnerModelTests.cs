using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Tests
{
    [TestClass()]
    public class RechnerModelTests
    {
        RechnerModel model = new RechnerModel();

        [TestMethod()]
        public void Berechne_DivisionDurchNull_ErgibtUnendlich()
        {
            model.Operation = "/";
            model.ErsteZahl = 10;
            model.ZweiteZahl = 0;

            model.Berechne();

            Assert.AreEqual(double.PositiveInfinity, model.Resultat);
        }

        [TestMethod]
        public void PruefeAddition()
        {
            model.ErsteZahl = 10.3;
            model.ZweiteZahl = 9.3;
            model.Operation = "+";

            model.Berechne();

            Assert.AreEqual(19.6, model.Resultat);
        }

        [TestMethod]
        public void PruefeSubtraktion()
        {
            model.ErsteZahl = 10.0;
            model.ZweiteZahl = 5.0;
            model.Operation = "-";

            model.Berechne();

            Assert.AreEqual(5.0, model.Resultat);
        }

        [TestMethod]
        public void PruefeMultiplikation()
        {
            model.ErsteZahl = 10.2;
            model.ZweiteZahl = 2.0;
            model.Operation = "*";

            model.Berechne();

            Assert.AreEqual(20.4, model.Resultat);
        }
    }
}