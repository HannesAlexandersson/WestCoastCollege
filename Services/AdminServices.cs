using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.Services;

public class AdminServices : IService<Admin, AdminRestDb>
{
    public async Task Add(Admin item)
    {
        var httpService = new HttpService<Admin>();
        await httpService.Post("admins", item);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Admin>();
        await httpService.Delete("admins", id);
    }

    public async Task<AdminRestDb> Find(string id)
    {
        var httpService = new HttpService<AdminRestDb>();
        var searchCriteria = "{\"personellId\":" + "\"" + id + "\"}";
        return await httpService.Get("admins", searchCriteria);
    }

    public async Task<List<Admin>> List()
    {
        var httpService = new HttpService<Admin>();
        var admins = await httpService.Get("admins");
        return admins;
    }

    public async Task Update(Admin admin, string _objectId)
    {
        var httpService = new HttpService<Admin>();
        await httpService.Put("admins", admin, _objectId);
    }
}
