using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Factories;

public class HandlerFactory : IHandlerFactory
{
    public Handler Create(DateTime dateOfEmployment, string officeLocation, string firstName, string lastName, string phoneNumber, List<Address> addresses, string? email, FieldOfKnowledge[] subjectFields, Course[] handlingCourses, AccessLevelEnum accessLevel)
    {
        return new Handler
        {
            DateOfEmployment = dateOfEmployment,
            OfficeLocation = officeLocation,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Addresses = addresses,
            Email = email,
            TeacherId = Guid.NewGuid().ToString(),
            HandlingCourses = handlingCourses,
            SubjectFields = subjectFields,
            AccessLevel = accessLevel
        };
    }
}
