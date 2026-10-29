
using System;
using System.Collections.Generic;

namespace WestCoastCollege.Models;


public record class Student : Person

{
    public string StudentId { get; set; } = string.Empty;
    public List<Course> EnrolledCourses { get; set; } = [];

}
