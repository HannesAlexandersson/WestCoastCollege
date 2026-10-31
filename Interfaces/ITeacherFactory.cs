using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

public interface ITeacherFactory
{
    Teacher Create(
         string firstName,
            string lastName,
            string phoneNumber,
            List<Address> addresses,
            string? email,
            FieldOfKnowledge[] subjectFields,
            Guid teacherId
    );
}
