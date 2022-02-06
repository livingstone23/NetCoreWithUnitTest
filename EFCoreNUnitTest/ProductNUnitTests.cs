using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore;
using Moq;
using NUnit.Framework;

namespace EFCoreNUnitTest
{

    [TestFixture]
    public class ProductNUnitTests
    {

        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(40));
        }


        //Usando Mock en la clase.
        [Test]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));
        }




    }

}
