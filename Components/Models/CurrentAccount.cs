namespace Bank.Components.Models
{
    class CurrentAccount : Account
    {
        public CurrentAccount(string number, double balance, double creditLine, Person owner) : base(number, balance, creditLine, owner) { }
        public CurrentAccount(string number, double balance, Person owner) : base(number, balance, 0, owner) { }
        public CurrentAccount(string number, Person owner) : base(number, 0, 100, owner) { }
        public override void Withdraw(double amount)
        {
            if (Balance > 0 && Balance - amount < 0)
            {
                OnNegativeBalance();
            }
            base.Withdraw(amount);
        }
        public override double CalculInterests()
        {
            Console.WriteLine("Calcul des interets...");
            return Balance >= 0 ? Balance * 0.03 : Balance * 0.0975;
        }

    }
}
