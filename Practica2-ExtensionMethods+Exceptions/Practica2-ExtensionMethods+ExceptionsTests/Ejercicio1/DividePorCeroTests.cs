using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2_ExtensionMethods_Exceptions.Ejercicio1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionMethods_ExceptionsTests.Ejercicio1
{
    [TestClass]
    public class DividePorCeroTests
    {
        private StringWriter stringWriter;
        private TextWriter originalConsoleOut;

        [TestInitialize]
        public void Initialize()
        {
            stringWriter = new StringWriter();
            originalConsoleOut = Console.Out;
            Console.SetOut(stringWriter);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.SetOut(originalConsoleOut);
            stringWriter.Dispose();
        }

        [TestMethod]
        public void TestDividirPorCero_DivideByZeroException()
        {
            // Arrange (preparar)
            string input = "10"; // Simulando la entrada del usuario
            Console.SetIn(new StringReader(input)); // Redirige la entrada estándar a "input"

            // Act (actuar)
            DividePorCero.DividirPorCero();

            // Assert (afirmar)
            string consoleOutput = stringWriter.ToString();
            Assert.IsTrue(consoleOutput.Contains("No se puede dividir por cero"));
        }

        [TestMethod]
        public void TestDividirPorCero_FormatException()
        {
            // Arrange (preparar)
            string input = "texto"; // Simulando una entrada no numérica del usuario
            Console.SetIn(new StringReader(input)); // Redirige la entrada estándar a "input"

            // Act (actuar)
            DividePorCero.DividirPorCero();

            // Assert (afirmar)
            string consoleOutput = stringWriter.ToString();
            Assert.IsTrue(consoleOutput.Contains("El valor ingresado no es un numero"));
        }
    }
}
