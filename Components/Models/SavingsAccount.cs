namespace Bank.Components.Models
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string number, double balance, Person owner) : base(number, balance, 0, owner) { }
        public SavingsAccount(string number, Person owner) : base(number, 0, 0, owner) { }
        public DateTime DateLastWithdraw { get; private set; }
        public override double CalculInterests()
        {
            Console.WriteLine("Calcul des interets...");
            return Balance * 0.0045;
        }
    }
}
