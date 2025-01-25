namespace Bank.Components.Models
{
    public interface IBankAccount : IAccount
    {
        void ApplyInterests();
        Person Owner { get; }
        string Number { get; }
    }
}
