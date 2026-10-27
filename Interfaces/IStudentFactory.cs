using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

public interface IStudentFactory
{
    Student Create(
        string firstName,
        string lastName,
        string phoneNumber,
        List<Address> addresses,
        string? email,
        Guid studentId,
        List<Course> enrolledCourses
    );
}
