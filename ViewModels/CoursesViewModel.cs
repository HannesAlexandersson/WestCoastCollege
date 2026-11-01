using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly IService<Course, CourseRestDb>? _courseService;
    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];
    public CoursesViewModel()
    {
        PageTitle = "Courses";
    }
    public CoursesViewModel(IService<Course, CourseRestDb> service)
    {
        PageTitle = "Courses";
        _courseService = service;

        Init();
    }

    [RelayCommand]
    public async Task Delete(string id)
    {
        try
        {
            CourseRestDb course = await _courseService!.Find(id);
            if (course is not null)
            {
                await _courseService.Delete(course._id);
                await LoadCourses();
            }
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
        }
    }

    private async void Init()
    {
        await LoadCourses();
    }

    private async Task LoadCourses()
    {
        try
        {
            Courses = new ObservableCollection<Course>(await _courseService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
