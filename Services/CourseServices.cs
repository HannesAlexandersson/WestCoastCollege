using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.Services;

public class CourseServices : IService<Course> // implement the interface whit the list method
{
    public List<Course> GetList()
    {
        var db = new DataBase<Course>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/courses.json");
        var courses = db.Read(path);
        return courses;
    }
}
