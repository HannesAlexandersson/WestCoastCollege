using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Enums;
using WestCoastCollege.Factories;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;
using WestCoastCollege.Services;
using System.Linq;

namespace WestCoastCollege.ViewModels;

public partial class EditCourseViewModel : ViewModelBase, IInitializableViewModel
{
    private readonly IService<Course, CourseRestDb>? _courseService;
    private readonly IService<Teacher, TeacherRestDb>? _teacherService;
    private string _courseId = string.Empty;
    private readonly ICourseFactory? _courseFactory;
    [ObservableProperty]
    private ObservableCollection<Teacher> _teachers = [];

    [ObservableProperty]
    private Teacher? _selectedTeacher;
    [ObservableProperty]
    public partial string CourseId { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string TitleOfCourse { get; set; } = string.Empty;
    [ObservableProperty]
    public partial int LengthOfCourse { get; set; }
    [ObservableProperty]
    public partial DateTime StartDateOfCourse { get; set; }
    [ObservableProperty]
    public partial DateTime EndDateOfCourse { get; set; }

    [ObservableProperty]
    public partial Teacher TeacherOfcourse { get; set; }
    [ObservableProperty]
    public partial CourseTypeEnum TypeOfCourse { get; set; }

    public EditCourseViewModel(IService<Course, CourseRestDb> service, ICourseFactory courseFactory, IService<Teacher, TeacherRestDb> teacherService)
    {
        _courseService = service;
        _teacherService = teacherService;
        PageTitle = "Edit a course info";
        _courseFactory = courseFactory;
    }
    public async Task Init(string id)
    {
        _courseId = id;
        await GetCourse();
        await LoadTeachers();

        SelectedTeacher = Teachers.FirstOrDefault(
     t => t.TeacherId == TeacherOfcourse!.TeacherId
 );
    }

    private async Task LoadTeachers()
    {
        Teachers = new ObservableCollection<Teacher>(
            await _teacherService!.List()
        );
    }
    private async Task GetCourse()
    {
        try
        {
            var course = await _courseService!.Find(_courseId);

            if (course == null)
            {
                Console.WriteLine($"No student found with ID: {_courseId}");
                return;
            }

            CourseId = course.CourseId.ToString();
            TitleOfCourse = course.Title;
            LengthOfCourse = course.CourseLength;
            StartDateOfCourse = course.StartDate;
            EndDateOfCourse = course.EndDate;
            TeacherOfcourse = course.CourseTeacher;
            TypeOfCourse = course.CourseType;
        }
        catch (Exception ex)
        {

            throw new Exception($"No course found with ID: {_courseId}. {ex.Message}");
        }

    }

    [RelayCommand]
    private async Task Save()
    {
        Course course = _courseFactory!.Create(
            TitleOfCourse,
            LengthOfCourse,
            StartDateOfCourse,
            EndDateOfCourse,
            TeacherOfcourse,
            TypeOfCourse
        );

        await _courseService!.Update(course, _courseId);
    }
}
