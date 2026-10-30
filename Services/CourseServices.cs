using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.Services;

public class CourseServices : IService<Course, CourseRestDb> // implement the interface whit the list method
{
    public async Task Add(Course course)
    {
        var httpService = new HttpService<Course>();
        await httpService.Post("courses", course);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Course>();
        await httpService.Delete("courses", id);
    }

    public async Task<CourseRestDb> Find(string id)
    {
        var httpService = new HttpService<CourseRestDb>();
        var searchCriteria = "{\"courseId\":" + "\"" + id + "\"}";
        return await httpService.Get("courses", searchCriteria);
    }

    public async Task<List<Course>> List()
    {
        var httpService = new HttpService<Course>();
        var courses = await httpService.Get("courses");
        return courses;
    }

    public async Task Update(Course course, string _objectId)
    {
        var httpService = new HttpService<Course>();
        await httpService.Put("courses", course, _objectId);
    }
}
