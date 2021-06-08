using System;

namespace ClassLibrary
{
    public interface ITransactions
    {
        int Amount { get; set; }
        DateTime TransactionDate { get; set; }
        string TransactionDescription { get; set; }
        int TransactionId { get; set; }
        string TransactonType { get; set; }
    }
}