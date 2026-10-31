using System;
using WestCoastCollege.Models;

namespace WestCoastCollege.RestDbModels;

public record TeacherRestDb : Teacher
{
    public string _id { get; set; } = string.Empty;
}

