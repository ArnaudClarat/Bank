namespace Bank.Components.Models
{
    class InsuficientBalanceException : Exception
    {
        public InsuficientBalanceException(string message) : base(message) { }
    }
}
