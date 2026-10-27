using WestCoastEducation.Classes;

namespace WestCoastEducation.Models;

public record class Person
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public List<Address> Addresses { get; set; } = []; // composition. An address is created when the person instance is created and it cannot live anywhere in the app on its own. 
    public string? Email { get; set; }
}
