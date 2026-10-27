using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

public interface ITeacherFactory
{
    Teacher Create(
         string firstName,
            string lastName,
            string phoneNumber,
            List<Address> addresses,
            string? email,
            FieldOfKnowledge[] subjectFields,
            Course[] teachingCourses,
            Guid teacherId
    );
}
