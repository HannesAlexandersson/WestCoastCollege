using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Enums;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Factories;

public class AdminFactory : IAdminFactory
{
    public Admin Create(DateTime dateOfEmployment, string officeLocation, string firstName, string lastName, string phoneNumber, List<Address> addresses, string? email, FieldOfKnowledge[] subjectFields, Course[] teachingCourses, Guid teacherId, AccessLevelEnum accessLevel, bool isSuperAdmin)
    {
        return new Admin
        {
            DateOfEmployment = dateOfEmployment,
            OfficeLocation = officeLocation,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Addresses = addresses,
            Email = email,
            TeacherId = teacherId,
            SubjectFields = subjectFields,
            TeachingCourses = teachingCourses,
            AccessLevel = accessLevel,
            IsSuperAdmin = isSuperAdmin
        };
    }
}
