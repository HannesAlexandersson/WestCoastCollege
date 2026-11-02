using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;
using System.Linq;
using WestCoastCollege.Classes;

namespace WestCoastCollege.ViewModels;

public partial class AddNewTeacherViewModel : ViewModelBase
{
    private readonly IService<Course, CourseRestDb>? _courseService; // we need to let the user choose a course from the actual list of courses
    private readonly IService<Teacher, TeacherRestDb>? _teacherService;
    private readonly ITeacherFactory? _teacherFactory;
    private readonly MainWindowViewModel? _mainWindowVm;

    [ObservableProperty]
    private ObservableCollection<Teacher> _teachers = [];

    [ObservableProperty]
    private Teacher? _selectedTeacher;
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }
    [ObservableProperty]
    private ObservableCollection<Course> _courses = [];
    [ObservableProperty]
    private Course? _selectedCourse;
    [ObservableProperty]
    public partial string TeacherId { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string FirstNameOfTeacher { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string LastNameOfTeacher { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string PhoneNumberOfTeacher { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string EmailOfTeacher { get; set; } = string.Empty;

    [ObservableProperty]
    public partial ObservableCollection<Address> TeacherAddresses { get; set; } = [];
    [ObservableProperty]
    public partial ObservableCollection<FieldOfKnowledge> TeacherSubjectFields { get; set; } = [];


    public AddNewTeacherViewModel()
    {
        PageTitle = "Add new teacher";
    }
    public AddNewTeacherViewModel(IService<Course, CourseRestDb> service, ITeacherFactory teacherFactory, MainWindowViewModel mainWindowVm, IService<Teacher, TeacherRestDb> teacherService)
    {
        PageTitle = "Add new teacher";
        _courseService = service;
        _teacherFactory = teacherFactory;
        _mainWindowVm = mainWindowVm;
        _teacherService = teacherService;
    }

    public async Task Init()
    {
        await LoadCourses();
    }

    private async Task LoadCourses()
    {
        Courses = new ObservableCollection<Course>(
            await _courseService!.List()
        );
    }

    [RelayCommand]
    private void AddAddress()
    {
        TeacherAddresses.Add(new Address
        {
            StreetAddress = "",
            PostalCode = 0.ToString(),
            City = ""
        });
    }

    [RelayCommand]
    private void RemoveAddress(Address address)
    {
        TeacherAddresses.Remove(address);
    }

    [RelayCommand]
    private void AddSubjectField()
    {
        TeacherSubjectFields.Add(new FieldOfKnowledge
        {
            NameOfSubject = ""
        });
    }

    [RelayCommand]
    private void RemoveSubjectField(FieldOfKnowledge subject)
    {
        TeacherSubjectFields.Remove(subject);
    }
    [RelayCommand]
    private async Task Save()
    {
        try
        {

            //validate input??

            _mainWindowVm!.IsBusy = true;
            //validate userinput???
            Teacher teacher = _teacherFactory!.Create(
               FirstNameOfTeacher,
            LastNameOfTeacher,
            PhoneNumberOfTeacher,
            TeacherAddresses.ToList(),
            EmailOfTeacher,
            TeacherSubjectFields.ToArray()
          );

            await _teacherService!.Add(teacher);
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
        FirstNameOfTeacher = string.Empty;
        LastNameOfTeacher = string.Empty;
        PhoneNumberOfTeacher = string.Empty;
        EmailOfTeacher = string.Empty;
        TeacherAddresses = [];
        TeacherSubjectFields = [];

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
