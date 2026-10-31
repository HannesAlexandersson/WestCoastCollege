using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Enums;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

public interface IAdminFactory
{
    Admin Create(
        DateTime dateOfEmployment,
        string officeLocation,
        string firstName,
        string lastName,
        string phoneNumber,
        List<Address> addresses,
        string? email,
         FieldOfKnowledge[] subjectFields,
            Guid teacherId,
            AccessLevelEnum accessLevel,
            bool isSuperAdmin
    );
}
