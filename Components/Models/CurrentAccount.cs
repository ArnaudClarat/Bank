namespace Bank.Components.Models
{
    /// <summary>
    /// Represents a current bank account with a credit line.
    /// </summary>
    class CurrentAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the CurrentAccount class with the specified account number, owner, balance, and credit line.
        /// </summary>
        public CurrentAccount(string number, Person owner, double balance = 0, double creditLine = 0, double positiveInterest = 0.03, double negativeInterest = 0.0975) : base(number, owner, balance, creditLine)
        {
            PositiveInterest = positiveInterest;
            NegativeInterest = negativeInterest;
        }
        /// <summary>
        /// Withdraws the specified amount from the account, ensuring no overdraft beyond the credit line.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public override void Withdraw(double amount)
        {
            CheckNegativeBalance();
            base.Withdraw(amount);
        }
    }
}
