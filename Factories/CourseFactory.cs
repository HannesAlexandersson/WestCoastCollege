using System;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Factories;
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
