namespace ClassLibrary.Account
{
    public interface ICurrentAccount : IAccount
    {
        int TotalOverdraftBalance { get; }
    }
}