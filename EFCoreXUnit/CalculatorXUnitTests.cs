using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore;
using Xunit;


namespace EFCoreNUnitTest
{


    public class CalculatorXUnitTests
    {



        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {

            //Arrange
            Calculator calc = new Calculator();


            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.Equal(30, result);


        }



        [Fact]
        public void IsOddChecker_InputEventNumber_ReturnFalse()
        {

            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(10);
            //Assert.That(isOdd, Is.EqualTo(false));

            //Realiza la misma confirmacion que en la parte superior
            Assert.False(isOdd);
        }



        [Fact]
        public void IsOddChecker_InputOffNumber_ReturnTrue()
        {

            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(11);
            //Assert.That(isOdd, Is.EqualTo(true));

            //Realiza la misma confirmacion que en la parte superior
            Assert.True(isOdd);
        }



        /// <summary>
        /// Definiendo multiples parametros de envio.
        /// </summary>
        /// <param name="a"></param>
        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {

            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(a);
            //Assert.That(isOdd, Is.EqualTo(true));

            //Realiza la misma confirmacion que en la parte superior
            Assert.False(isOdd);

        }



        /// <summary>
        /// Parametros y definiendo respuesta.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {

            Calculator calc = new();
            var result = calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);

        }


        /// <summary>
        /// Realizando pruebas con dobles
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Theory]
        [InlineData(5.4, 10.5)] //15.9
        [InlineData(5.43, 10.53)] // 15.93
        [InlineData(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new();

            //Act
            double result = calc.AddNumbersDouble(a, b);



            //Assert
            //.2 permite un rango de variante
            Assert.Equal(15.9, result, 0);
            //15.7-16.1
        }



        /// <summary>
        /// Asserting Collections
        /// </summary>
        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

            //act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);

            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);

            Assert.DoesNotContain(6,result);
            Assert.Equal(result.OrderBy(u =>u), result);
            //Assert.That(result, Is.Unique);

        }


    }


   

}
