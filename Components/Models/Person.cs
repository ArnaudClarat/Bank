using Bank.Components.Services;
using System.ComponentModel.DataAnnotations;

namespace Bank.Components.Models
{
    public class Person(string firstName, string lastName, DateTime birthDate)
    {
        [Required(ErrorMessage = "Firstname is requiered")]
        public string FirstName { get; set; } = firstName;
        [Required(ErrorMessage = "Lastname is requiered")]
        public string LastName { get; set; } = lastName;
        [Required(ErrorMessage = "Birth Date is required.")]
        [DynamicDateRange(MinAge = 18, MaxAge = 180, ErrorMessage = "Birth Date must be between 18 and 180.")]
        public DateTime BirthDate { get; set; } = birthDate;
    }
}
