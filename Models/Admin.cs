using System;
using WestCoastCollege.Enums;

namespace WestCoastCollege.Models;

public record class Admin : AdminPersonel
{
    public bool IsSuperAdmin { get; set; }
    public AccessLevelEnum AccessLevel { get; set; }
}
