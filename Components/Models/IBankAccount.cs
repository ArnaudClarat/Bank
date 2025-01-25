namespace Bank.Components.Models
{
    public interface IBankAccount : IAccount
    {
        /// <summary>
        /// Applies interest to the current balance.
        /// </summary>
        void ApplyInterests();
        Person Owner { get; }
        string Number { get; }
    }
}
