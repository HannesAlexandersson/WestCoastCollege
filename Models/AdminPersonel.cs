using System;
using WestCoastCollege.Enums;

namespace WestCoastCollege.Models;

public record class AdminPersonel : Teacher
{
    public DateTime DateOfEmployment { get; set; }
    public OfficeLocationEnum OfficeLocation { get; set; }
    public string PersonellId { get; set; } = string.Empty;
}
