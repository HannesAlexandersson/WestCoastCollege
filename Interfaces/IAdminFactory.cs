using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Enums;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

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
            Course[] teachingCourses,
            Guid teacherId,
            AccessLevelEnum accessLevel,
            bool isSuperAdmin
    );
}
