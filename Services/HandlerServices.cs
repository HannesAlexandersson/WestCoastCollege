using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.Services;

public class HandlerServices : IService<Handler, HandlerRestDb>
{
    public async Task Add(Handler item)
    {
        var httpService = new HttpService<Handler>();
        await httpService.Post("handler", item);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Handler>();
        await httpService.Delete("handler", id);
    }

    public async Task<HandlerRestDb> Find(string id)
    {
        var httpService = new HttpService<HandlerRestDb>();
        var searchCriteria = "{\"handlerId\":" + "\"" + id + "\"}";
        return await httpService.Get("handler", searchCriteria);
    }

    public async Task<List<Handler>> List()
    {
        var httpService = new HttpService<Handler>();
        var handlers = await httpService.Get("handler");
        return handlers;
    }

    public async Task Update(Handler item, string _objectId)
    {
        var httpService = new HttpService<Handler>();
        await httpService.Put("handler", item, _objectId);
    }
}
