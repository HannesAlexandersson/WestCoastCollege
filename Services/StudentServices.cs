using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.Services;

public class StudentServices : IService<Student>
{
    public List<Student> GetList()
    {
        var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        var students = db.Read(path);
        return students;
    }
}
