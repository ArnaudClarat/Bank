namespace Bank.Components.Models
{
    public interface IAccount
    {
        double Balance { get; }
        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit, must be positive.</param>
        void Deposit(double amount);
        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw, must not exceed the balance.</param>
        /// <exception cref="InsufficientBalanceException">Thrown when the withdrawal amount exceeds the current balance.</exception>
        void Withdraw(double amount);
    }
}
