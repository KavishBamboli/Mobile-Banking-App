using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class SavingsAccount : IAccount
    {
        private ITransactions _transaction;
        public int accNo { get; set; }
        public int balance { get; set; }

        public SavingsAccount(ITransactions transaction)
        {
            _transaction = transaction;
        }
        public bool MakeDeposit(int amount, string details)
        {
            balance += amount;
            _transaction.Amount = amount;
            _transaction.TransactionDate = DateTime.Today;
            _transaction.TransactionDescription = details;
            _transaction.TransactonType = "Credit";
            _transaction.TransactionId = 1; //Transaction id generator;
            RecordTransaction.SaveToFile(_transaction);
            return true;

        }

        public bool MakeWithdrawal(int amount, string details)
        {
            if (balance < amount)
                return false;
            else
            {
                balance -= amount;
                _transaction.Amount = amount;
                _transaction.TransactionDate = DateTime.Today;
                _transaction.TransactionDescription = details;
                _transaction.TransactonType = "Debit";
                _transaction.TransactionId = 1; //Transaction id generator;
                RecordTransaction.SaveToFile(_transaction);
                return true;
            }
        }
    }
}
