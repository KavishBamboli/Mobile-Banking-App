using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal static class RecordTransaction
    {
        internal static ITransactions Record(int amount, DateTime date, string details, string type, AccountType account)
        {
            ITransactions transaction = new Transactions();

            transaction.Amount = amount;
            transaction.TransactionId = TransactionIdGenerator.GenerateId(account);
            transaction.TransactionDate = date;
            transaction.TransactionDescription = details;
            transaction.TransactonType = type;

            return transaction;
        }
    }
}
