using System;
using System.Collections.ObjectModel;
using System.Linq;
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

    private readonly MainWindowViewModel? _mainWindowVm;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];
    public CoursesViewModel()
    {
        PageTitle = "Courses";
    }
    public CoursesViewModel(IService<Course, CourseRestDb> service, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Courses";
        _courseService = service;
        _mainWindowVm = mainWindowVm;
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

    [RelayCommand]
    public void ShowPopUp(string courseId)
    {
        _mainWindowVm!.IsBusy = true;
        SelectedCourse = Courses.FirstOrDefault(s => s.CourseId == courseId);
        if (SelectedCourse is not null)
        {
            ShowDialog = true;
        }

    }
    [RelayCommand]
    private async Task Confirm()
    {
        if (SelectedCourse is null)
            return;

        try
        {
            await Delete(SelectedCourse.CourseId);
            ShowDialog = false;
            SelectedCourse = null;
            _mainWindowVm!.IsBusy = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    private void Abort()
    {
        ShowDialog = false;

        _mainWindowVm!.IsBusy = false;
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
