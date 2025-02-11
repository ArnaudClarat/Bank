using Bank.Components.Models;

public class BankState
{
    public List<Person> Customers { get; set; } = [];
    public List<BankAccount> Accounts { get; set; } = [];
}