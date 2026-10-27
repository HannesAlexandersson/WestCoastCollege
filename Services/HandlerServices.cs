using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.Services;

public class HandlerServices : IService<Handler>
{
    public List<Handler> GetList()
    {
        var db = new DataBase<Handler>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/handlers.json");
        var handlers = db.Read(path);
        return handlers;
    }
}
