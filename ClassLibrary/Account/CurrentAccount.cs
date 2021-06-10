using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class CurrentAccount : IAccount
    {
        ITransactions _transaction;
        public int accNo { get; set; }
        public int balance { get; set; }
        public int TotalOverdraftBalance { get; private set; }

        public CurrentAccount(ITransactions transaction)
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
            _transaction.TransactionId = TransactionIdGenerator.GenerateId(AccountType.Current);
            RecordTransaction.SaveToFile(_transaction);
            return true;
        }

        public bool MakeWithdrawal(int amount, string details)
        {
            if (balance < amount)
            {
                if (MakeOverdraft(balance - amount))
                {
                    balance -= amount;
                    _transaction.Amount = amount;
                    _transaction.TransactionDate = DateTime.Today;
                    _transaction.TransactionDescription = details;
                    _transaction.TransactonType = "Debit";
                    _transaction.TransactionId = TransactionIdGenerator.GenerateId(AccountType.Current);
                    RecordTransaction.SaveToFile(_transaction);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                balance -= amount;
                _transaction.Amount = amount;
                _transaction.TransactionDate = DateTime.Today;
                _transaction.TransactionDescription = details;
                _transaction.TransactonType = "Debit";
                _transaction.TransactionId = TransactionIdGenerator.GenerateId(AccountType.Current);
                RecordTransaction.SaveToFile(_transaction);
                return true;
            }
        }

        private bool MakeOverdraft(int amount)
        {
            if (TotalOverdraftBalance < 100000)
            {
                if ((amount + TotalOverdraftBalance) > 100000)
                    return false;
                else
                {
                    TotalOverdraftBalance += amount;
                    return true;
                }
            }
            else
                return false;
        }
    }
}
