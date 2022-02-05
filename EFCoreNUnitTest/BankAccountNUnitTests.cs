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
    public class BankAccountNUnitTests
    {

        //private BankAccount bankAccount;

        //Manera incorrecta de probar
        //[SetUp]
        //public void steup()
        //{
        //    bankAccount = new(new LogBook());
        //}


        //[Test]
        //public void BankDeposit_Add100_ReturnTrue()
        //{

        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));


        //}

        private BankAccount account;


        [SetUp]
        public void steup()
        {
            
        }


        //Otra manera de realizarlo
        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnTrue()
        //{
        //    BankAccount bankAccount = new(new LogFakker());
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //
        //}


        /// <summary>
        /// Primer metodo que se implementa Mock
        /// </summary>
        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.Message(""));


            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }


        /// <summary>
        /// Usando TestCase 049 -MOQ Setup with Conditional Return.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="withdraw"></param>
        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withrdraw(withdraw);
            Assert.IsTrue(result);
        }


        /// <summary>
        /// Usando IsInRange, 050 -MOQ setup default return value.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="withdraw"></param>
        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withrdraw(withdraw);
            Assert.IsFalse(result);
        }




    }
}
