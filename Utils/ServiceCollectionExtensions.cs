using System;
using Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WestCoastCollege.Classes;
using WestCoastCollege.Factories;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;
using WestCoastCollege.Services;
using WestCoastCollege.ViewModels;

namespace WestCoastCollege.Utils;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        //collection.AddSingleton<ApplicationData>(); // we also need the appdata as long as the app will live    



        collection.AddTransient<ICourseFactory, CourseFactory>(); // when someone want to use the interface, give them the factory
        collection.AddTransient<IAdminFactory, AdminFactory>();
        collection.AddTransient<ITeacherFactory, TeacherFactory>();
        collection.AddTransient<IHandlerFactory, HandlerFactory>();
        collection.AddTransient<IStudentFactory, StudentFactory>();


        collection.AddTransient<IService<Student, StudentRestDb>, StudentServices>();
        collection.AddTransient<IService<Course, CourseRestDb>, CourseServices>(); // IF anyone ever wants the Iservice then we give then the servoice
        // collection.AddTransient<IService<Teacher>, TeacherServices>();
        // collection.AddTransient<IService<Admin>, AdminServices>();
        // collection.AddTransient<IService<Handler>, HandlerServices>();

        collection.AddTransient(typeof(IHttpService<>), typeof(HttpService<>));

    }
}
