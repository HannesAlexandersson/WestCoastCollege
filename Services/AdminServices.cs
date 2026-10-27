using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.Services;

public class AdminServices : IService<Admin>
{
    public List<Admin> GetList()
    {
        var db = new DataBase<Admin>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/admins.json");
        var admins = db.Read(path);
        return admins;
    }
}
