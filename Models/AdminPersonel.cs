using System;

namespace WestCoastCollege.Models;

public record class AdminPersonel : Teacher // according to the written assignment the admin personell should have EVERYTHING a teacher has, how unlogical it may seem to me...
{
    public DateTime DateOfEmployment { get; set; }
    public string OfficeLocation { get; set; } = "";
}
