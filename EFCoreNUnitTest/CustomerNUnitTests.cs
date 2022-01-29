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
    public class CustomerNUnitTests
    {
        private Customer customer;

        /// <summary>
        /// Metodo para inicializar la clases que utiliza el atributo [SetUp]
        /// </summary>
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }


        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange 
            //se define al inicio de la clase y se inicializa.
            //var customer = new Customer()

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert Multiple
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }


        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange

            //act

            //assert
            Assert.IsNull(customer.GreetMessage);
        }



    }

}
