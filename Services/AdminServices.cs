using System;
using System.Collections.Generic;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Services;

public class AdminServices : IService<Admin>
{
    public List<Admin> GetList()
    {
        /* var db = new DataBase<Admin>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/admins.json");
        var admins = db.Read(path);
        return admins; */
        return [];
    }
}
