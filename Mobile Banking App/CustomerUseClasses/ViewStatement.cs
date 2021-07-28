using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    public static class ViewStatement
    {
        public static void View(ICustomer customer)
        {
            PrintLine();
            PrintRow("Transaction Id", "Date", "Details", "Amount", "Debit/Credit");
            PrintLine();
            foreach(var t in customer.Account.transactions)
            {
                PrintRow($"{t.TransactionId}", $"{t.TransactionDate.ToShortDateString()}", $"{t.TransactionDescription}", $"{t.Amount}", $"{t.TransactonType}");
            }
            PrintLine();

        }
        static void PrintLine()
        {
            Console.WriteLine(new string('-', 150));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (150 - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
