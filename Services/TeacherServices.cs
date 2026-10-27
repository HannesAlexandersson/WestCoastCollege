using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.Services;

public class TeacherServices : IService<Teacher>
{
    public List<Teacher> GetList()
    {
        var db = new DataBase<Teacher>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/teachers.json");
        var teachers = db.Read(path);
        return teachers;
    }
}
