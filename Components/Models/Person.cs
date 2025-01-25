namespace Bank.Components.Models
{
    public class Person(string firstName, string lastName, DateTime birthDate)
    {
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public DateTime BirthDate { get; set; } = birthDate;
    }
}
