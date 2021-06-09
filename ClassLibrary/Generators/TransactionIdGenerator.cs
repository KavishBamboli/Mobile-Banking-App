using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal static class TransactionIdGenerator
    {
        internal static int GenerateId(AccountType type)
        {
            Random rand = new Random();
            if(type == AccountType.Savings)
            {
                return int.Parse(string.Concat("11", Convert.ToString(rand.Next(100000, 999999))));
            }
            else if(type == AccountType.Current)
            {
                return int.Parse(string.Concat("91", Convert.ToString(rand.Next(100000, 999999))));
            }
            return 0;
        }
    }
}
