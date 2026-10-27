using System;
using WestCoastEducation.Enums;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

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
