using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;


namespace WestCoastCollege.ViewModels;

public partial class AddNewCourseViewModel : ViewModelBase
{
    private readonly IService<Course, CourseRestDb>? _courseService;
    private readonly IService<Teacher, TeacherRestDb>? _teacherService; // we need to let the user choose a teacher from the actual list of teachers
    private readonly ICourseFactory? _courseFactory;
    private readonly MainWindowViewModel? _mainWindowVm;

    [ObservableProperty]
    private ObservableCollection<Teacher> _teachers = [];

    [ObservableProperty]
    private Teacher? _selectedTeacher;
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    [ObservableProperty]
    public partial string TitleOfCourse { get; set; } = string.Empty;
    [ObservableProperty]
    public partial int LengthOfCourse { get; set; }
    [ObservableProperty]
    public partial DateTime? StartDateOfCourse { get; set; }
    [ObservableProperty]
    public partial DateTime? EndDateOfCourse { get; set; }

    [ObservableProperty]
    public partial CourseTypeEnum TypeOfCourse { get; set; }

    public AddNewCourseViewModel()
    {
        PageTitle = "Add new course";
    }
    public AddNewCourseViewModel(IService<Course, CourseRestDb> service, ICourseFactory courseFactory, MainWindowViewModel mainWindowVm, IService<Teacher, TeacherRestDb> teacherService) // inject the course factory, and mainwindowvm with DI
    {
        PageTitle = "Add new course";
        _courseService = service;

        _courseFactory = courseFactory;
        _mainWindowVm = mainWindowVm;
        _teacherService = teacherService;
    }

    public async Task Init()
    {
        await LoadTeachers();
    }

    private async Task LoadTeachers()
    {
        Teachers = new ObservableCollection<Teacher>(
            await _teacherService!.List()
        );
    }

    [RelayCommand]
    private async Task Save()
    {
        try
        {

            //validate input??
            if (SelectedTeacher is null ||
              StartDateOfCourse is null ||
              EndDateOfCourse is null)
            {
                return;
            }
            _mainWindowVm!.IsBusy = true;
            //validate userinput???
            Course course = _courseFactory!.Create(
              TitleOfCourse,
              LengthOfCourse,
              StartDateOfCourse.Value,
              EndDateOfCourse.Value,
              SelectedTeacher,
              TypeOfCourse
          );

            await _courseService!.Add(course);
            ClearData();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            ShowDialog = false;
            _mainWindowVm!.IsBusy = false;
        }

    }
    [RelayCommand]
    private void ClearData()
    {
        TitleOfCourse = string.Empty;
        LengthOfCourse = 0;
        StartDateOfCourse = null;
        EndDateOfCourse = null;
        SelectedTeacher = null;
        TypeOfCourse = 0;
    }
    [RelayCommand]
    public void ShowPopUp()
    {
        _mainWindowVm!.IsBusy = true;
        ShowDialog = true;
    }
    [RelayCommand]
    private async Task Confirm()
    {
        await Save();
    }
    [RelayCommand]
    private void Abort()
    {
        ShowDialog = false;

        _mainWindowVm!.IsBusy = false;
    }
}
