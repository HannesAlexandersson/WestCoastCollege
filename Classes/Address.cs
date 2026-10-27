namespace WestCoastCollege.Classes;

public class Address
{
    public required string StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; } = "";
}
