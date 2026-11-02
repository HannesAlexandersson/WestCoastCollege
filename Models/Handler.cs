using WestCoastCollege.Enums;

namespace WestCoastCollege.Models;


public record class Handler : AdminPersonel

{
    public Course[] HandlingCourses { get; set; } = [];
    public AccessLevelEnum AccessLevel { get; set; }
}
