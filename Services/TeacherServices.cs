using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.Services;

public class TeacherServices : IService<Teacher, TeacherRestDb>
{
    public async Task Add(Teacher teacher)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Post("teachers", teacher);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Delete("teachers", id);
    }

    public async Task<TeacherRestDb> Find(string id)
    {
        var httpService = new HttpService<TeacherRestDb>();
        var searchCriteria = "{\"teacherId\":" + "\"" + id + "\"}";
        return await httpService.Get("teachers", searchCriteria);
    }

    public async Task<List<Teacher>> List()
    {
        var httpService = new HttpService<Teacher>();
        var teachers = await httpService.Get("teachers");
        return teachers;
    }

    public async Task Update(Teacher item, string _objectId)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Put("teachers", item, _objectId);
    }
}
