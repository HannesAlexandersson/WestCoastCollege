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
        await httpService.Post("handlers", item);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Handler>();
        await httpService.Delete("handlers", id);
    }

    public async Task<HandlerRestDb> Find(string id)
    {
        var httpService = new HttpService<HandlerRestDb>();
        var searchCriteria = "{\"personellId\":" + "\"" + id + "\"}";
        return await httpService.Get("handlers", searchCriteria);
    }

    public async Task<List<Handler>> List()
    {
        var httpService = new HttpService<Handler>();
        var handlers = await httpService.Get("handlers");
        return handlers;
    }

    public async Task Update(Handler item, string _objectId)
    {
        var httpService = new HttpService<Handler>();
        await httpService.Put("handlers", item, _objectId);
    }
}
