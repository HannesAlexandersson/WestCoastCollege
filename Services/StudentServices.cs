using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.Services;

public class StudentServices : IService<Student, StudentRestDb>
{
    public async Task Add(Student student)
    {
        var httpService = new HttpService<Student>();
        await httpService.Post("students", student);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Student>();
        await httpService.Delete("students", id);
    }

    public async Task<StudentRestDb> Find(string itemNumber)
    {
        var httpService = new HttpService<StudentRestDb>();
        var searchCriteria = "{\"itemNumber\":" + "\"" + itemNumber + "\"}";
        return await httpService.Get("students", searchCriteria);
    }

    public async Task<List<Student>> List()
    {
        var httpService = new HttpService<Student>();
        var students = await httpService.Get("students");
        return students;
    }

    public async Task Update(Student student, string _objectId)
    {
        var httpService = new HttpService<Student>();
        await httpService.Put("students", student, _objectId);
    }
}
