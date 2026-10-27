using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Enums;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Factories;

public class HandlerFactory : IHandlerFactory
{
    public Handler Create(DateTime dateOfEmployment, string officeLocation, string firstName, string lastName, string phoneNumber, List<Address> addresses, string? email, FieldOfKnowledge[] subjectFields, Course[] teachingCourses, Guid teacherId, Course[] handlingCourses, AccessLevelEnum accessLevel)
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
            TeacherId = teacherId,
            TeachingCourses = teachingCourses,
            HandlingCourses = handlingCourses,
            SubjectFields = subjectFields,
            AccessLevel = accessLevel
        };
    }
}
