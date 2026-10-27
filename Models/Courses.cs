using WestCoastEducation.Enums;

namespace WestCoastEducation.Models;

public record class Course
{
    public Guid CourseId { get; set; }
    public required string Title { get; set; }
    public int CourseLength { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid[] CoursePersonnelIds { get; set; } = [];
    public CourseTypeEnum CourseType { get; set; }
}
