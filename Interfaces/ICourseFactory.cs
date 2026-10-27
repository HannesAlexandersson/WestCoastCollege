using System;
using WestCoastCollege.Enums;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

public interface ICourseFactory
{
    Course Create(
            string title,
            int courseLength,
            DateTime startDate,
            DateTime endDate,
            Guid[] teacherIds,
            CourseTypeEnum courseType);
}
