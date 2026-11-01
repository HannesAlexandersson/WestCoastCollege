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

public partial class EditTeacherViewModel : ViewModelBase, IInitializableViewModel
{
    private readonly IService<Teacher, TeacherRestDb>? _teacherService;
    private readonly IService<Course, CourseRestDb>? _courseService;
    private string _teacherId = string.Empty;
    private readonly ITeacherFactory? _teacherFactory;

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

    public EditTeacherViewModel(IService<Teacher, TeacherRestDb> service, IService<Course, CourseRestDb> courseService, ITeacherFactory factory)
    {
        PageTitle = "Edit a teacher info";
        _teacherFactory = factory;
        _teacherService = service;
        _courseService = courseService;
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
    { //TODO fix the view the addrsses only have one textbox, none for postalcode or city
        try
        {
            var teacher = await _teacherService!.Find(_teacherId);

            TeacherId = teacher.TeacherId.ToString();
            FirstNameOfTeacher = teacher.FirstName;
            LastNameOfTeacher = teacher.LastName;
            PhoneNumberOfTeacher = teacher.PhoneNumber;
            EmailOfTeacher = teacher.Email ?? ""; // email is allowed to be null/empty string
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
        Teacher teacher = _teacherFactory!.Create(
            FirstNameOfTeacher,
            LastNameOfTeacher,
            PhoneNumberOfTeacher,
            TeacherAddresses.ToList(),
            EmailOfTeacher,
            TeacherSubjectFields.ToArray()
        );

        await _teacherService!.Update(teacher, _teacherId);
    }
}
