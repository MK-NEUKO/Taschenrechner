using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Taschenrechner.Tests
{
    // TODO Tests vervollständigen, Exeptions prüfen, Überlauf...

    [TestClass()]
    public class RechnerModelTests
    {
        RechnerModel model = new RechnerModel();

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Berechne_FalscherOperator()
        {
            // Arrange
            model.Operation = "x";
            model.ErsteZahl = 8;
            model.ZweiteZahl = 4;
            // Act
            try
            {
                model.Berechne();
            }
            catch (ArgumentException ex)
            {
                //Assert
                Assert.AreEqual("Gültige Operatoren sind (+ | - | * | / )", ex.Message);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Berechne_WertebereichErsteZahlObergrenze()
        {
            // Arrange
            model.Operation = "/";
            model.ErsteZahl = 101;
            model.ZweiteZahl = 8;
            // Act
            try
            {
                model.Berechne();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                Assert.AreEqual("Wertebereich = -10 bis 100", ex.Message);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Berechne_WertebereichZweiteZahlObergrenze()
        {
            // Arrange
            model.Operation = "/";
            model.ErsteZahl = 8;
            model.ZweiteZahl = 101;
            // Act
            try
            {
                model.Berechne();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                Assert.AreEqual("Wertebereich = -10 bis 100", ex.Message);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Berechne_WertebereichZweiteZahlUntergrenze()
        {
            // Arrange
            model.Operation = "/";
            model.ErsteZahl = 8;
            model.ZweiteZahl = -11;
            // Act
            try
            {
                model.Berechne();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                Assert.AreEqual("Wertebereich = -10 bis 100", ex.Message);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Berechne_WertebereichErsteZahlUntergrenze()
        {
            // Arrange
            model.Operation = "/";
            model.ErsteZahl = -11;
            model.ZweiteZahl = 5;
            // Act
            try
            {
                model.Berechne();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                Assert.AreEqual("Wertebereich = -10 bis 100", ex.Message);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Test_Division_DivisionDurchNull()
        {
            // Arrange
            model.Operation = "/";
            model.ErsteZahl = 10;
            model.ZweiteZahl = 0;
            // Act
            try
            {
                model.Berechne();
            }
            catch (DivideByZeroException ex)
            {
                //Assert
                Assert.AreEqual("Unzulässige Division durch '0'.", ex.Message);
                throw;
            }                    
        }

        [TestMethod]
        public void Test_Addition()
        {
            model.ErsteZahl = 10.3;
            model.ZweiteZahl = 9.3;
            model.Operation = "+";

            model.Berechne();

            Assert.AreEqual(19.6, model.Resultat);
        }

        [TestMethod]
        public void Test_Subtraktion()
        {
            model.ErsteZahl = 10.0;
            model.ZweiteZahl = 5.0;
            model.Operation = "-";

            model.Berechne();

            Assert.AreEqual(5.0, model.Resultat);
        }

        [TestMethod]
        public void Test_Multiplikation()
        {
            model.ErsteZahl = 10.2;
            model.ZweiteZahl = 2.0;
            model.Operation = "*";

            model.Berechne();

            Assert.AreEqual(20.4, model.Resultat);
        }
    }
}