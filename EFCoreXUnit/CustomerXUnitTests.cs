using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore;
using Xunit;


namespace EFCoreNUnitTest
{



    public class CustomerXUnitTests
    {


        private Customer customer;


        /// <summary>
        /// Metodo para inicializar la clases que utiliza el atributo [SetUp]
        /// </summary>
        
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }


        /// <summary>
        /// Using Assert.Multiple
        /// </summary>
        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange 
            //se define al inicio de la clase y se inicializa.
            //var customer = new Customer()

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Multiple donot exist in NUNit
            //Assert Multiple
            //Assert.Multiple(() =>
            //{
                Assert.Equal("Hello, Ben Spark",customer.GreetMessage );
                Assert.Contains("ben Spark".ToLower(), customer.GreetMessage.ToLower());
                Assert.StartsWith("Hello,", customer.GreetMessage);
                Assert.EndsWith("Spark", customer.GreetMessage);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
            //});
        }


        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange

            //act

            //assert
            Assert.Null(customer.GreetMessage);
        }


        /// <summary>
        /// Using InRange
        /// </summary>
        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }


        /// <summary>
        /// Probando metodo que requiere al menos primer nombre
        /// </summary>
        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);

            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));

        }


        /// <summary>
        /// Manejando excepciones
        /// </summary>
        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {

            //Realizamos la captura de la excepcion.
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            //Comparamos las excepciones con el control esperado.
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            //Segunda forma de controlar la misma excepcion.
            //Assert.That(() => customer.GreetAndCombineNames("", "spark"),
            //    Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));


            //Controlamos solo que se genera la excepcion.
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

            ////Segunda forma de confirmar que se genera la excepcion.
            //Assert.That(() => customer.GreetAndCombineNames("", "spark"),
            //    Throws.ArgumentException);
        }


        /// <summary>
        /// Testing Setup inheritance  (Herencia de configuración)
        /// </summary>
        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }


        /// <summary>
        ///  Testing Setup inheritance  (Herencia de configuración)
        /// </summary>
        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }



    }

}
