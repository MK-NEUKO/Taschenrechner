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
        public void Pruefe_AdditionAufGrenzwerte()
        {
            model.Operation = "+";
            model.ErsteZahl = -10.0;
            model.ZweiteZahl = 100.0;

            model.Berechne();

            Assert.AreEqual(90, model.Resultat);
        }
    }
}