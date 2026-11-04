using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Classes;
using WestCoastCollege.Factories;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;
using System.Linq;


namespace WestCoastCollege.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    private readonly IService<Teacher, TeacherRestDb>? _teacherService;
    private readonly IService<Course, CourseRestDb>? _courseService;
    private readonly MainWindowViewModel? _mainWindowVm;
    private string _teacherId = string.Empty;
    private string _objectId = string.Empty;
    private readonly ITeacherFactory? _teacherFactory;
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


    public EditTeacherViewModel()
    {
        PageTitle = "Edit a teacher info";
    }

    public EditTeacherViewModel(IService<Teacher, TeacherRestDb> service, IService<Course, CourseRestDb> courseService, ITeacherFactory factory, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Edit a teacher info";
        _teacherFactory = factory;
        _teacherService = service;
        _courseService = courseService;
        _mainWindowVm = mainWindowVm;
    }

    public async Task Init(string id)
    {
        _teacherId = id;
        await GetTeacher();
        await LoadCourses();
    }
    private async Task LoadCourses()
    {
        Courses = new ObservableCollection<Course>(
            await _courseService!.List()
        );
    }
    private async Task GetTeacher()
    {
        try
        {
            var teacher = await _teacherService!.Find(_teacherId);
            if (teacher == null)
            {
                Console.WriteLine($"No teacher found with ID: {_teacherId}");
                return;
            }
            _objectId = teacher._id;
            TeacherId = teacher.TeacherId.ToString();
            FirstNameOfTeacher = teacher.FirstName;
            LastNameOfTeacher = teacher.LastName;
            PhoneNumberOfTeacher = teacher.PhoneNumber;
            EmailOfTeacher = teacher.Email ?? "";
            TeacherAddresses = new ObservableCollection<Address>(teacher.Addresses);
            TeacherSubjectFields = new ObservableCollection<FieldOfKnowledge>(teacher.SubjectFields);
        }
        catch (Exception ex)
        {

            throw new Exception($"No teacher found with ID: {_teacherId}. {ex.Message}");
        }

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
            _mainWindowVm!.IsBusy = true;
            Teacher teacher = _teacherFactory!.Create(
           FirstNameOfTeacher,
           LastNameOfTeacher,
           PhoneNumberOfTeacher,
           TeacherAddresses.ToList(),
           EmailOfTeacher,
           TeacherId,
           TeacherSubjectFields.ToArray()
       );

            await _teacherService!.Update(teacher, _objectId);

            ShowDialog = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            _mainWindowVm!.IsBusy = false;
            ClearData();
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
