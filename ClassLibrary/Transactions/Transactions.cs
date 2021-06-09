using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Transactions : ITransactions
    {
        public int TransactionId { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactonType { get; set; }
        public int Amount { get; set; }
    }
}
