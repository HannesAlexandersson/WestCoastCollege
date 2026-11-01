using System;

namespace WestCoastCollege.Models;

public record class AdminPersonel : Teacher
{
    public DateTime DateOfEmployment { get; set; }
    public string OfficeLocation { get; set; } = string.Empty;
    public string PersonellId { get; set; } = string.Empty;
}
