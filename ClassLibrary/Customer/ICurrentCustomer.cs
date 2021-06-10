using ClassLibrary.Account;

namespace ClassLibrary.Customer
{
    public interface ICurrentCustomer : ICustomer
    {
        string OwnerName { get; set; }
    }
}