using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class SavingsAccount : IAccount, ISavingsAccount
    {
        public int accNo { get; set; }
        public int balance { get; set; }
        public List<ITransactions> transactions { get; set; } = new List<ITransactions>();
        
        public bool MakeDeposit(int amount, string details)
        {
            if (amount < 20000)
            {
                balance += amount;
                var transaction = RecordTransaction.Record(amount, DateTime.Today, details, "Credit", AccountType.Savings);
                SaveTransactionToFile.Save(accNo, transaction);
                SaveChangesToFile.Save(accNo, balance, AccountType.Savings);
                transactions.Add(transaction);
                return true;
            }
            else
                return false;
        }

        public bool MakeWithdrawal(int amount, string details)
        {
            if (balance < amount || amount > 10000 || (balance - amount) < 1200)
                return false;
            else
            {
                balance -= amount;
                var transaction = RecordTransaction.Record(amount, DateTime.Today, details, "Debit", AccountType.Savings);
                SaveTransactionToFile.Save(accNo, transaction);
                SaveChangesToFile.Save(accNo, balance, AccountType.Savings);
                transactions.Add(transaction);
                return true;
            }
        }
    }
}
