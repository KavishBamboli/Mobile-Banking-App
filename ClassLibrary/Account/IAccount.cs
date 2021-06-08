namespace ClassLibrary.Account
{
    public interface IAccount
    {
        int accNo { get; set; }
        int balance { get; set; }
        bool MakeDeposit(int amount, string message);
        bool MakeWithdrawal(int amount, string details);    
    }
}