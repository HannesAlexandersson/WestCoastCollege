using System;
using WestCoastEducation.Enums;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Factories;
// the factorys job is to create the course objects
public class CourseFactory : ICourseFactory
{
    public Course Create(string title, int courseLength, DateTime startDate, DateTime endDate, Guid[] teacherIds, CourseTypeEnum courseType)
    {
        return new Course
        {
            CourseId = Guid.NewGuid(),
            Title = title,
            CourseLength = courseLength,
            StartDate = startDate,
            EndDate = endDate,
            CoursePersonnelIds = teacherIds,
            CourseType = courseType
        };
    }
}
