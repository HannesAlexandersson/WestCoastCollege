using WestCoastEducation.Classes;


namespace WestCoastEducation.Models;

public record class Teacher : Person // teacher inherits from the baseclass 'Person'

{
    public FieldOfKnowledge[] SubjectFields { get; set; } = []; // composition, the Subjectfields/FieldOfKnowledge only creates when a teacher instane is created. 
    public Course[] TeachingCourses { get; set; } = []; // aggregation, the courses exist without a teacher object
    public Guid TeacherId { get; set; }
}
