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
        public int balance { get; set; } = 50000;
        public List<ITransactions> transactions { get; set; } = new List<ITransactions>();
        public SavingsAccount(ITransactions transaction)
        {
            _transaction = transaction;
        }
        public bool MakeDeposit(int amount, string details)
        {
            if (amount > 20000)
            {
                balance += amount;
                _transaction.Amount = amount;
                _transaction.TransactionDate = DateTime.Today;
                _transaction.TransactionDescription = details;
                _transaction.TransactonType = "Credit";
                _transaction.TransactionId = TransactionIdGenerator.GenerateId(AccountType.Savings);
                transactions.Add(_transaction);
                RecordTransaction.SaveToFile(_transaction);
                return true;
            }
            else
                return false;

        }

        public bool MakeWithdrawal(int amount, string details)
        {
            if (balance < amount || amount > 10000)
                return false;
            else
            {
                balance -= amount;
                _transaction.Amount = amount;
                _transaction.TransactionDate = DateTime.Today;
                _transaction.TransactionDescription = details;
                _transaction.TransactonType = "Debit";
                _transaction.TransactionId = TransactionIdGenerator.GenerateId(AccountType.Current);
                transactions.Add(_transaction);
                RecordTransaction.SaveToFile(_transaction);
                return true;
            }
        }
    }
}
