using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

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
