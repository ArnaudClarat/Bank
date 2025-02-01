using System.Numerics;
using System.Security.Cryptography;

namespace Bank.Components.Models
{
    /// <summary>
    /// Initializes a new instance of the Account class with a specified account number, balance, credit line, and owner.
    /// </summary>
    public abstract class BankAccount : IBankAccount
    {
        public string Number { get; set; }
        public double Balance { get; set; }
        public double CreditLine { get; set; }
        public double PositiveInterest { get; protected set; }
        public double NegativeInterest { get; protected set; }
        public DateTime DateLastWithdraw { get; private set; }
        public Person Owner { get; set; }
        public event Action<BankAccount>? NegativeBalanceEvent;
        /// <summary>
        /// Initializes a new instance of the BankAccount class with a specified account number, balance, credit line, and owner.
        /// </summary>
        protected BankAccount(string number, Person owner, double balance = 0, double creditLine = 0)
        {
            if (creditLine < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(creditLine), "CreditLine must be greater than or equal to 0.");
            }
            Number = number;
            Balance = balance;
            CreditLine = creditLine;
            Owner = owner;
        }
        /// <summary>
        /// Withdraws a specified amount from the account if the balance allows.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public virtual void Withdraw(double amount)
        {
            if (Balance - amount >= -CreditLine)
            {
                Balance -= amount;
                Console.WriteLine($"{amount}€ has been withdrawed successfully.");
                CheckNegativeBalance();
            }
            else
            {
                throw new InsufficientBalanceException(amount, Balance);
            }
        }
        /// <summary>
        /// Deposits a specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"{amount}€ has been deposited successfully");
                CheckNegativeBalance();
            }
            else
            {
                throw new ArgumentOutOfRangeException(null, "Veuillez inserez un montant positif");
            }
        }
        /// <summary>
        /// Applies interest to the balance based on the account's specific logic.
        /// </summary>
        public void ApplyInterests()
        {
            Balance += Math.Round(CalculInterests(), 2);
            CheckNegativeBalance();
        }
        /// <summary>
        /// Abstract method to calculate the interest for the specific account.
        /// </summary>
        public double CalculInterests()
        {
            Console.WriteLine("Calcul des interets...");
            return Balance >= 0 ? Balance * PositiveInterest : Balance * NegativeInterest;
        }
        /// <summary>
        /// Notifies the NegativeBalanceEvent if the balance is negative.
        /// </summary>
        protected void CheckNegativeBalance()
        {
            if (Balance < 0)
            {
                Console.WriteLine("Warning, your balance is negative.");
                NegativeBalanceEvent?.Invoke(this);
            }
        }

        public static bool IsValidBankAccount(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban)) return false;

            iban = iban.Replace(" ", "").Trim().ToUpper();

            if (!iban.StartsWith("BE") || iban.Length != 16 || !iban.Skip(2).All(char.IsDigit))
                return false;

            string checksum = iban.Substring(2, 2);
            string accountNumber = iban.Substring(4, 12);

            string numericIBAN = accountNumber + "1114" + checksum; // "B"=11, "E"=14
            BigInteger ibanNumber = BigInteger.Parse(numericIBAN);

            return ibanNumber % 97 == 1;
        }
        public static string GenerateValidBelgianIBAN()
        {
            byte[] buffer = new byte[5];
            RandomNumberGenerator.Fill(buffer); 

            long baseNumber = BitConverter.ToUInt32(buffer, 0) % 10000000000L;

            string numericIBAN = baseNumber.ToString("D10") + "1114"; // "BE" = 1114
            BigInteger ibanNumber = BigInteger.Parse(numericIBAN);

            int controlKey = (int)(98 - (ibanNumber % 97));

            return $"BE{controlKey:D2}{baseNumber:D10}";
        }
    }
}
