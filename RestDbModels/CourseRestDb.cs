using System;
using WestCoastCollege.Models;

namespace WestCoastCollege.RestDbModels;

public record CourseRestDb : Course
{
    public string _id { get; set; } = string.Empty;
}
