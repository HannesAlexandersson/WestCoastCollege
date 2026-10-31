using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Factories;

public class AdminFactory : IAdminFactory
{
    public Admin Create(DateTime dateOfEmployment, string officeLocation, string firstName, string lastName, string phoneNumber, List<Address> addresses, string? email, FieldOfKnowledge[] subjectFields, Guid teacherId, AccessLevelEnum accessLevel, bool isSuperAdmin)
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
            AccessLevel = accessLevel,
            IsSuperAdmin = isSuperAdmin
        };
    }
}
