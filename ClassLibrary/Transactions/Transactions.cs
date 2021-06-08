using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Transactions : ITransactions
    {
        public int TransactionId { get; internal set; }
        public string TransactionDescription { get; internal set; }
        public DateTime TransactionDate { get; internal set; }
        public string TransactonType { get; internal set; }
        public int Amount { get; internal set; }
    }
}
