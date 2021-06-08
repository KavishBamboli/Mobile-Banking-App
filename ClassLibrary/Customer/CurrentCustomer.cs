using ClassLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Customer
{
    public class CurrentCustomer : ICustomer
    {
        private IAccount _account;
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public int LoginPin { get; internal set; }

        public CurrentCustomer(IAccount account)
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
