using ClassLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Customer
{
    public class SavingsCustomer : ICustomer, ISavingsCustomer
    {
        private IAccount _account;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int LoginPin { get; internal set; }

        public SavingsCustomer(IAccount account)
        {
            _account = account;
        }
        public IAccount Account
        {
            get { return _account; }
            set { _account = value; }
        }
    }
}
