namespace Bank.Components.Models
{
    abstract class Account : IBankAccount
    {
        public string Number { get; private set; }
        public double Balance { get; private set; }
        public double CreditLine { get; private set; }
        public Person Owner { get; private set; }
        //public delegate void NegativeBalanceDelegate(Account account);
        public event Action<Account>? NegativeBalanceEvent;
        protected Account(string number, double balance, double creditLine, Person owner)
        {
            if (creditLine < 0)
            {
                throw new ArgumentOutOfRangeException(null, "CreditLine must be greater than or equal to 0.");
            }
            Number = number;
            Balance = balance;
            CreditLine = creditLine;
            Owner = owner;
        }
        protected Account(string number, Person owner) : this(number, 0, 0, owner) { }
        protected Account(string number, double balance, Person owner) : this(number, balance, 0, owner) { }
        public virtual void Withdraw(double amount)
        {
            if (Balance - amount >= -CreditLine)
            {
                Balance -= amount;
                Console.WriteLine($"{amount}€ has been withdrawed successfully.");
                if (Balance < 0)
                {
                    Console.WriteLine("Warning, your balance is negative.");
                }
            }
            else
            {
                throw new InsuficientBalanceException($"Insuficent fonds to withdraw {amount}€");
            }
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"{amount}€ has been deposited successfully");
                if (Balance < 0)
                {
                    Console.WriteLine("Warning, your balance is negative.");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(null, "Veuillez inserez un montant positif");
            }
        }
        public void ApplyInterests()
        {
            Balance += CalculInterests();
        }
        public abstract double CalculInterests();
        protected void OnNegativeBalance()
        {
            NegativeBalanceEvent?.Invoke(this);
        }

    }
}
