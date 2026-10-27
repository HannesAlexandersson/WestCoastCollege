using System;
using System.Collections.Generic;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Services;

public class StudentServices : IService<Student>
{
    public List<Student> GetList()
    {
        /* var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        var students = db.Read(path);
        return students; */
        return [];
    }
}
