using System;
using System.Collections.Generic;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Services;

public class TeacherServices : IService<Teacher>
{
    public List<Teacher> GetList()
    {
        /*  var db = new DataBase<Teacher>();
         var path = string.Concat(Environment.CurrentDirectory, "/Data/teachers.json");
         var teachers = db.Read(path);
         return teachers; */
        return [];
    }
}
