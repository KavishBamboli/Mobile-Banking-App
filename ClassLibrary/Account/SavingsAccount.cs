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
        public int balance { get; set; }
        public bool MakeDeposit(int amount)
        {
            balance += amount;
            return true;
        }

        public bool MakeWithdrawal(int amount)
        {
            if (balance < amount)
                return false;
            else
            {
                balance -= amount;
                return true;
            }
        }
    }
}
