using System;
using System.Collections.Generic;
using WestCoastCollege.Enums;

namespace WestCoastCollege.Models;

public record class Course
{
    public string CourseId { get; set; } = string.Empty;
    public required string Title { get; set; }
    public int CourseLength { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required Teacher CourseTeacher { get; set; }
    public CourseTypeEnum CourseType { get; set; }
}
