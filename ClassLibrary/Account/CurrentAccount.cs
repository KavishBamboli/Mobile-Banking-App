using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class CurrentAccount : IAccount, ICurrentAccount
    {
        public int accNo { get; set; }
        public int balance { get; set; } = 500000;
        public int TotalOverdraftBalance { get; private set; }
        public List<ITransactions> transactions { get; set; } = new List<ITransactions>();

        public bool MakeDeposit(int amount, string details)
        {
            if (amount < 100000)
            {
                balance += amount;
                transactions.Add(RecordTransaction.Record(amount, DateTime.Today, details, "Credit", AccountType.Current));
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
                    transactions.Add(RecordTransaction.Record(amount, DateTime.Today, details, "Debit", AccountType.Current));
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
                    transactions.Add(RecordTransaction.Record(amount, DateTime.Today, details, "Debit", AccountType.Current));
                    TotalOverdraftBalance += amount;
                    return true;
                }
            }
            else
                return false;
        }
    }
}
