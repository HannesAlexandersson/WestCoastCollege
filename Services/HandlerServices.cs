using System;
using System.Collections.Generic;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Services;

public class HandlerServices : IService<Handler>
{
    public List<Handler> GetList()
    {
        /* var db = new DataBase<Handler>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/handlers.json");
        var handlers = db.Read(path);
        return handlers; */
        return [];
    }
}
