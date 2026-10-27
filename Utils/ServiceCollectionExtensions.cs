using System;
using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Classes;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Managers;
using WestCoastEducation.Menus;
using WestCoastEducation.Models;
using WestCoastEducation.Services;

namespace WestCoastEducation.Utils;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<App>(); //we want an app that starts and lives for as long as the program runs
        collection.AddSingleton<ApplicationData>(); // we also need the appdata as long as the app will live

        collection.AddTransient<Menu>(); // everytihng else we want to create when they are needed and discard when they arent needed

        collection.AddTransient<StudentManager>();
        collection.AddTransient<TeacherManager>();
        collection.AddTransient<AdminManager>();
        collection.AddTransient<HandlerManager>();
        collection.AddTransient<CourseManager>();

        collection.AddTransient<ICourseFactory, CourseFactory>(); // when someone want to use the interface, give them the factory
        collection.AddTransient<IAdminFactory, AdminFactory>();
        collection.AddTransient<ITeacherFactory, TeacherFactory>();
        collection.AddTransient<IHandlerFactory, HandlerFactory>();
        collection.AddTransient<IStudentFactory, StudentFactory>();


        collection.AddTransient<IService<Course>, CourseServices>(); // IF anyone ever wants the Iservice then we give then the servoice
        collection.AddTransient<IService<Student>, StudentServices>();
        collection.AddTransient<IService<Teacher>, TeacherServices>();
        collection.AddTransient<IService<Admin>, AdminServices>();
        collection.AddTransient<IService<Handler>, HandlerServices>();

    }
}
