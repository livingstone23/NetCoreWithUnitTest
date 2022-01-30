using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore;
using NUnit.Framework;

namespace EFCoreNUnitTest
{

    [TestFixture]
    public class CalculatorNUnitTests
    {


        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {

            //Arrange
            Calculator calc = new Calculator();


            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.AreEqual(30, result);


        }


        [Test]
        public void IsOddChecker_InputEventNumber_ReturnFalse()
        {

            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));

            //Realiza la misma confirmacion que en la parte superior
            Assert.IsFalse(isOdd);
        }


        [Test]
        public void IsOddChecker_InputOffNumber_ReturnTrue()
        {

            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(11);
            Assert.That(isOdd, Is.EqualTo(true));

            //Realiza la misma confirmacion que en la parte superior
            Assert.IsTrue(isOdd);
        }



        /// <summary>
        /// Definiendo multiples parametros de envio.
        /// </summary>
        /// <param name="a"></param>
        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOffNumber_ReturnTruePassingArgument(int a)
        {

            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(a);
            Assert.That(isOdd, Is.EqualTo(true));

            //Realiza la misma confirmacion que en la parte superior
            Assert.IsTrue(isOdd);
        }



        /// <summary>
        /// Parametros y definiendo respuesta.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);
        }


        /// <summary>
        /// Realizando pruebas con dobles
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] // 15.93
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new();

            //Act
            double result = calc.AddNumbersDouble(a, b);



            //Assert
            //.2 permite un rango de variante
            Assert.AreEqual(15.9, result, .2);
            //15.7-16.1
        }



        /// <summary>
        /// Asserting Collections
        /// </summary>
        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

            //act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            //Assert.AreEqual( expectedOddRange, result);
            //Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }


    }


   

}
