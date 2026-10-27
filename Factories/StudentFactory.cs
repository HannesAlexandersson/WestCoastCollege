using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Factories;

public class StudentFactory : IStudentFactory
{

    public Student Create(string firstName, string lastName, string phoneNumber, List<Address> addresses, string? email, Guid studentId, List<Course> enrolledCourses)
    {
        return new Student
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Addresses = addresses,
            Email = email,
            StudentId = studentId,
            EnrolledCourses = enrolledCourses
        };
    }
}
