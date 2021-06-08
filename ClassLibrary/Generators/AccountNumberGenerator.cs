using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class AccountNumberGenerator
    {
        public static int GenerateAccountNumber(AccountType type)
        {
            Random rand = new Random();
            if(type == AccountType.Savings)
            {
                return int.Parse(string.Concat("1001", Convert.ToString(rand.Next(10000, 99999))));
            }
            else if(type == AccountType.Current)
            {
                return int.Parse(string.Concat("9001", Convert.ToString(rand.Next(10000, 99999))));
            }
            return 0;
        }

    }
}
