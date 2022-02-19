using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {

        

        [Test]
        public void DateValidator_InputExpectedDateRange_DateValidity_Test()
        {

            DateInFutureAttribute dateInFutureAttribute = new(()=> DateTime.Now);
            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(100));
            Assert.AreEqual(true, result);


        }



        [TestCase(100, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        public bool DateValidator_InputExpectedDateRange_DateValidity_TestCase(int addTime)
        {

            DateInFutureAttribute dateInFutureAttribute = new(() => DateTime.Now);
            return dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addTime));

        }



        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {

            var result = new DateInFutureAttribute();
            Assert.AreEqual("Date must be in the future", result.ErrorMessage);

        }

    }

}
