
namespace WestCoastEducation.Models;


public record class Student : Person // Student inherits from the baseclass 'Person'

{
    public Guid StudentId { get; set; }
    public List<Course> EnrolledCourses { get; set; } = []; // Aggregation, the courses exists independently from the Students or better said: i dont need to createan student instance to create anew course

}
