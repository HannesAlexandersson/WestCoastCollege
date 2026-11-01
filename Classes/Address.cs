namespace WestCoastCollege.Classes;

public class Address
{
    public required string StreetAddress { get; set; }
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
