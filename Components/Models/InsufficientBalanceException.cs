namespace Bank.Components.Models
{
    class InsufficientBalanceException : Exception
    {
        public double RequestedAmount { get; }
        public double CurrentBalance { get; }

        public InsufficientBalanceException(string message) : base(message) { }

        public InsufficientBalanceException(double requestedAmount, double currentBalance, string message = "Insufficient funds")
            : base($"{message}. Requested Amount: {requestedAmount}, Current Balance: {currentBalance}")
        {
            RequestedAmount = requestedAmount;
            CurrentBalance = currentBalance;
        }

        // Example of overriding the ToString method for detailed logging
        public override string ToString()
        {
            return $"{base.ToString()}, Requested Amount: {RequestedAmount}, Current Balance: {CurrentBalance}";
        }
    }
}
