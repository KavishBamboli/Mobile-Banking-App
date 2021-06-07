namespace ClassLibrary.Account
{
    public interface IAccount
    {
        int accNo { get; set; }
        int balance { get; set; }
        bool MakeDeposit(int amount);
        bool MakeWithdrawal(int amount);    
    }
}