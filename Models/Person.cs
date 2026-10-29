using System.Collections.Generic;
using WestCoastCollege.Classes;

namespace WestCoastCollege.Models;

public record class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Address> Addresses { get; set; } = [];
    public string? Email { get; set; }
}
