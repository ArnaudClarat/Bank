namespace Bank.Components.Models
{
    public interface IAccount
    {
        double Balance { get; }
        void Deposit(double amount);
        void Withdraw(double amount);
    }
}
