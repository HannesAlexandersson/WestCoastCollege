using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Enums;
using WestCoastCollege.Factories;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.Services;

namespace WestCoastCollege.ViewModels;

public partial class EditStudentViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb>? _studentService;
    private readonly string _studentId = string.Empty;
    private readonly StudentFactory _studentFactory;

    [ObservableProperty]
    public partial string StudentId { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string FirstNameOfStudent { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string LastNameOfStudent { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string PhoneNumberOfStudent { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string EmailOfStudent { get; set; } = string.Empty;

    //TODO  addressess and courses???
    /*  [ObservableProperty]
      public partial List<Address> Addresses { get; set; } = []; */
    /* [ObservableProperty]
    public partial List<Course> EnrolledCourses { get; set; } = []; */
    public EditStudentViewModel()
    {
        _studentService = new StudentServices();
        PageTitle = "Edit a students data";
    }
    public EditStudentViewModel(string studentId)
    {
        _studentService = new StudentServices();
        PageTitle = "Edit a students data" + studentId;
        _studentId = studentId;
    }
    public EditStudentViewModel(string studentId, IService<Student, StudentRestDb> service)
    {
        PageTitle = "Edit a students data: " + studentId;
        _studentService = service;
        _studentId = studentId;
        Init();
    }
    public EditStudentViewModel(string studentId, IService<Student, StudentRestDb> service, StudentFactory studentFactory)
    {
        PageTitle = "Edit a students data: " + studentId;
        _studentService = service;
        _studentId = studentId;
        _studentFactory = studentFactory;
        Init();
    }

    private async void Init()
    {
        await GetStudent();
    }

    private async Task GetStudent()
    {
        var student = await _studentService!.Find(_studentId);
        // set the other propertys here !!!
        StudentId = student.StudentId;
        FirstNameOfStudent = student.FirstName;
        LastNameOfStudent = student.LastName;
        PhoneNumberOfStudent = student.PhoneNumber;
        EmailOfStudent = student.Email ?? ""; // emails is not required and can be left empty

    }

    [RelayCommand]
    private async Task Save()
    {
        Student student = new()
        {
            StudentId = StudentId.ToString(),
            FirstName = FirstNameOfStudent,
            LastName = LastNameOfStudent,
            PhoneNumber = PhoneNumberOfStudent,
            Email = EmailOfStudent
        };
        /* TODO: Add factorycreation with courses etc
           Student student = _studentFactory.Create
          (
              StudentId.ToString(),
              FirstNameOfStudent,
              LastNameOfStudent,
              PhoneNumberOfStudent,
              EmailOfStudent
         ) */
        ;

        await _studentService!.Update(student, _studentId);
    }
}
