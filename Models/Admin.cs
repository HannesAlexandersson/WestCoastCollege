using System;
using WestCoastEducation.Enums;

namespace WestCoastEducation.Models;

public record class Admin : AdminPersonel
{
    public bool IsSuperAdmin { get; set; }
    public AccessLevelEnum AccessLevel { get; set; }
}
