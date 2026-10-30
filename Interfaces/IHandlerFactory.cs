using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Enums;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

public interface IHandlerFactory
{
        Handler Create(
        DateTime dateOfEmployment,
        string officeLocation,
                string firstName,
        string lastName,
        string phoneNumber,
        List<Address> addresses,
        string? email,
        FieldOfKnowledge[] subjectFields,
        Guid teacherId,
        Course[] handlingCourses,
        AccessLevelEnum accessLevel
            );
}
