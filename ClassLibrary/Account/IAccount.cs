using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Account
{
    public interface IAccount
    {
        int accNo { get; set; }
        int balance { get; set; }
        List<ITransactions> transactions { get; set; }
        bool MakeDeposit(int amount, string message);
        bool MakeWithdrawal(int amount, string details);
    }
}
