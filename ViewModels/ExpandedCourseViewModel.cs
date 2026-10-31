using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedCourseViewModel : ViewModelBase
{
    private readonly IService<Course, CourseRestDb>? _courseService;
    private string _id = string.Empty;
    [ObservableProperty]
    public partial Course? Course { get; set; }

    public ExpandedCourseViewModel() { }

    public ExpandedCourseViewModel(IService<Course, CourseRestDb> courseService)
    {
        _courseService = courseService;
    }

    public async void Init(string id)
    {
        _id = id;
        await LoadCourse(id);
    }

    private async Task LoadCourse(string id)
    {
        try
        {
            Course = await _courseService!.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
