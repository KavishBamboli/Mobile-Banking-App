using ClassLibrary.Account;

namespace ClassLibrary.Customer
{
    public interface ISavingsCustomer : ICustomer
    {
        int Age { get; set; }
    }
}