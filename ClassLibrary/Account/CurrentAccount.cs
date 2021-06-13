using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class CurrentAccount : IAccount, ICurrentAccount
    {
        ITransactions _transaction;
        public int accNo { get; set; }
        public int balance { get; set; }
        public int TotalOverdraftBalance { get; private set; }
        public List<ITransactions> transactions { get; set; } = new List<ITransactions>();

        public CurrentAccount(ITransactions transaction)
        {
            _transaction = transaction;
        }

        public bool MakeDeposit(int amount, string details)
        {
            if (amount > 100000)
            {
                balance += amount;
                _transaction.Amount = amount;
                _transaction.TransactionDate = DateTime.Today;
                _transaction.TransactionDescription = details;
                _transaction.TransactonType = "Credit";
                _transaction.TransactionId = TransactionIdGenerator.GenerateId(AccountType.Current);
                transactions.Add(_transaction);
                RecordTransaction.SaveToFile(_transaction);
                return true;
            }
            else
                return false;
        }

        public bool MakeWithdrawal(int amount, string details)
        {
            if (amount < 50000)
            {
                if (balance < amount)
                {
                    if (MakeOverdraft(balance - amount, "Made overdarft from the account"))
                        return true;
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
                    transactions.Add(_transaction);
                    RecordTransaction.SaveToFile(_transaction);
                    return true;
                }
            }
            else
                return false;
        }

        private bool MakeOverdraft(int amount, string details)
        {
            if (TotalOverdraftBalance < 100000)
            {
                if ((amount + TotalOverdraftBalance) > 100000)
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
                    TotalOverdraftBalance += amount;
                    return true;
                }
            }
            else
                return false;
        }
    }
}
