using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {

            //Arrange
            Calculator calc = new Calculator();


            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.AreEqual(30, result);


        }

    }
}
