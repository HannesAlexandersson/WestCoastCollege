using System;
using Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WestCoastCollege.Classes;
using WestCoastCollege.Enums;
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

        collection.AddTransient<HomeViewModel>();

        collection.AddTransient<IStudentFactory, StudentFactory>();
        collection.AddTransient<IService<Student, StudentRestDb>, StudentServices>();
        collection.AddTransient<StudentsViewModel>();
        collection.AddTransient<EditStudentViewModel>();
        collection.AddTransient<ExpandedStudentViewModel>();

        collection.AddTransient<ICourseFactory, CourseFactory>();
        collection.AddTransient<IService<Course, CourseRestDb>, CourseServices>();
        collection.AddTransient<CoursesViewModel>();
        collection.AddTransient<ExpandedCourseViewModel>();
        collection.AddTransient<EditCourseViewModel>();
        collection.AddTransient<AddNewCourseViewModel>();


        collection.AddTransient<ITeacherFactory, TeacherFactory>();
        collection.AddTransient<IService<Teacher, TeacherRestDb>, TeacherServices>();
        collection.AddTransient<TeachersViewModel>();
        collection.AddTransient<EditTeacherViewModel>();
        collection.AddTransient<ExpandedTeacherViewModel>();
        collection.AddTransient<AddNewTeacherViewModel>();

        collection.AddTransient<IAdminFactory, AdminFactory>();
        collection.AddTransient<IService<Admin, AdminRestDb>, AdminServices>();
        collection.AddTransient<AdminsViewModel>();
        collection.AddTransient<ExpandedAdminViewModel>();

        collection.AddTransient<IHandlerFactory, HandlerFactory>();
        collection.AddTransient<IService<Handler, HandlerRestDb>, HandlerServices>();
        collection.AddTransient<HandlersViewModel>();
        collection.AddTransient<ExpandedHandlerViewModel>();

        collection.AddTransient(typeof(IHttpService<>), typeof(HttpService<>));
        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => name => name switch
                {
                    PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
                    PageViewsEnum.Students => c.GetRequiredService<StudentsViewModel>(),
                    PageViewsEnum.EditStudent => c.GetRequiredService<EditStudentViewModel>(),
                    PageViewsEnum.GoToStudent => c.GetRequiredService<ExpandedStudentViewModel>(),
                    PageViewsEnum.Courses => c.GetRequiredService<CoursesViewModel>(),
                    PageViewsEnum.EditCourse => c.GetRequiredService<EditCourseViewModel>(),
                    PageViewsEnum.GoToCourse => c.GetRequiredService<ExpandedCourseViewModel>(),
                    PageViewsEnum.AddNewCourse => c.GetRequiredService<AddNewCourseViewModel>(),
                    PageViewsEnum.Teachers => c.GetRequiredService<TeachersViewModel>(),
                    PageViewsEnum.GoToTeacher => c.GetRequiredService<ExpandedTeacherViewModel>(),
                    PageViewsEnum.EditTeacher => c.GetRequiredService<EditTeacherViewModel>(),
                    PageViewsEnum.AddNewTeacher => c.GetRequiredService<AddNewTeacherViewModel>(),
                    PageViewsEnum.Admins => c.GetRequiredService<AdminsViewModel>(),
                    PageViewsEnum.GoToAdmin => c.GetRequiredService<ExpandedAdminViewModel>(),
                    PageViewsEnum.Handlers => c.GetRequiredService<HandlersViewModel>(),
                    PageViewsEnum.GoToHandler => c.GetRequiredService<ExpandedHandlerViewModel>(),
                    _ => throw new ArgumentException("It didnt work")
                });
    }
}
