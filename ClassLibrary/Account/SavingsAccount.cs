using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class SavingsAccount : IAccount
    {
        public int accNo { get; set; }
        public int balance { get; set; } = 50000;
        public List<ITransactions> transactions { get; set; } = new List<ITransactions>();
        
        public bool MakeDeposit(int amount, string details)
        {
            if (amount < 20000)
            {
                balance += amount;
                transactions.Add(RecordTransaction.Record(amount, DateTime.Today, details, "Credit", AccountType.Savings));
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
                transactions.Add(RecordTransaction.Record(amount, DateTime.Today, details, "Debit", AccountType.Savings));
                return true;
            }
        }
    }
}
