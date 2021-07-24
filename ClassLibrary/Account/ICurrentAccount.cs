namespace ClassLibrary.Account
{
    public interface ICurrentAccount : ISavingsAccount
    {
        int TotalOverdraftBalance { get; set; }
    }
}