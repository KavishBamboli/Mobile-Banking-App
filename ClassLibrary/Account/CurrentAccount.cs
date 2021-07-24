using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class CurrentAccount : ISavingsAccount, ICurrentAccount
    {
        public int accNo { get; set; }
        public int balance { get; set; }
        public int TotalOverdraftBalance { get; set; }
        public List<ITransactions> transactions { get; set; } = new List<ITransactions>();

        public bool MakeDeposit(int amount, string details)
        {
            if (amount < 100000)
            {
                balance += amount;
                var transaction = RecordTransaction.Record(amount, DateTime.Today, details, "Credit", AccountType.Current);
                SaveTransactionToFile.Save(accNo, transaction);
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
                    var transaction = RecordTransaction.Record(amount, DateTime.Today, details, "Debit", AccountType.Current);
                    SaveTransactionToFile.Save(accNo, transaction);
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
                    var transaction = RecordTransaction.Record(amount, DateTime.Today, details, "Debit", AccountType.Current);
                    SaveTransactionToFile.Save(accNo, transaction);
                    return true;
                }
            }
            else
                return false;
        }
    }
}
