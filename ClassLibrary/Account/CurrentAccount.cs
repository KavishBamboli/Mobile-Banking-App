using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public class CurrentAccount : IAccount
    {
        public int accNo { get; set; }
        public int balance { get; set; }
        public int TotalOverdraftBalance { get; private set; }

        public bool MakeDeposit(int amount)
        {
            balance += amount;
            return true;
        }

        public bool MakeWithdrawal(int amount)
        {
            if (balance < amount)
            {
                if (MakeOverdraft(balance - amount))
                {
                    balance -= amount;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                balance -= amount;
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
