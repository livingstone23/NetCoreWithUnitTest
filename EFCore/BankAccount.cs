using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class BankAccount
    {

        public int balance { get; set; }

        private readonly ILogBook _logBook;
        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            balance = 0;
        }



        /// <summary>
        /// 057-MOQ Verification
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;
            balance += amount;
            return true;
        }



        //retiros
        public bool Withrdraw(int amount)
        {
            if (amount <= balance)
            {
                _logBook.LogToDb("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(balance);
            }
            return _logBook.LogBalanceAfterWithdrawal(balance - amount);
        }



        public int GetBalance()
        {
            return balance;
        }

    }


}
