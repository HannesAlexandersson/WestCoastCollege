using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Factories;

public class TeacherFactory : ITeacherFactory
{
    public Teacher Create(string firstName, string lastName, string phoneNumber, List<Address> addresses, string? email, FieldOfKnowledge[] subjectFields)
    {
        return new Teacher
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Addresses = addresses,
            Email = email,
            SubjectFields = subjectFields,
            TeacherId = Guid.NewGuid().ToString(),
        };
    }
}
