using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedCourseViewModel : ViewModelBase, IInitializableViewModel
{
    private readonly IService<Course, CourseRestDb>? _courseService;
    private string _courseId = string.Empty;
    [ObservableProperty]
    public partial Course? Course { get; set; }

    public ExpandedCourseViewModel() { }

    public ExpandedCourseViewModel(IService<Course, CourseRestDb> courseService)
    {
        _courseService = courseService;
    }

    public async Task Init(string id)
    {
        _courseId = id;
        await LoadCourse();
    }

    private async Task LoadCourse()
    {
        try
        {
            Course = await _courseService!.Find(_courseId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
