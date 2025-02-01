namespace Bank.Components.Models
{
    class SavingsAccount : BankAccount
    {
        public SavingsAccount(string number, Person owner, double balance = 0, double interest = 0.045) : base(number, owner, balance, 0) { PositiveInterest = interest; }
    }
}
