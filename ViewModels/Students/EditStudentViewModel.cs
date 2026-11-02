using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Classes;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;
using System.Linq;

namespace WestCoastCollege.ViewModels;

public partial class EditStudentViewModel : ViewModelBase, IInitializableViewModel
{
    private readonly IService<Student, StudentRestDb>? _studentService;
    private readonly IService<Course, CourseRestDb>? _courseService;
    private string _studentId = string.Empty;
    private readonly IStudentFactory? _studentFactory;

    [ObservableProperty]
    private ObservableCollection<Course> _courses = [];
    [ObservableProperty]
    private Course? _selectedCourse;
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
    [ObservableProperty]
    public partial ObservableCollection<Address> StudentAddresses { get; set; } = [];
    [ObservableProperty]
    public partial List<Course> StudentEnrolledCourses { get; set; } = [];
    public EditStudentViewModel()
    {
        PageTitle = "Edit a students data: ";
    }


    public EditStudentViewModel(IService<Student, StudentRestDb> service, IService<Course, CourseRestDb> courseService, IStudentFactory studentFactory)
    {
        PageTitle = "Edit a students data: ";
        _studentService = service;
        _courseService = courseService;
        _studentFactory = studentFactory;

    }

    public async Task Init(string id)
    {
        _studentId = id;
        await GetStudent();
        await LoadCourses();
    }
    private async Task LoadCourses()
    {
        Courses = new ObservableCollection<Course>(
            await _courseService!.List()
        );
    }
    private async Task GetStudent()
    { //TODO fix the edit view, addresses doesnt look agood, is to the side of the rest of the textboxes also add course neds styling, both bg and text are white there is no btns for saving or exit
        try
        {
            var student = await _studentService!.Find(_studentId);

            if (student == null)
            {
                Console.WriteLine($"No student found with ID: {_studentId}");
                return;
            }

            StudentId = student.StudentId;
            FirstNameOfStudent = student.FirstName;
            LastNameOfStudent = student.LastName;
            PhoneNumberOfStudent = student.PhoneNumber;
            EmailOfStudent = student.Email ?? "";
            StudentAddresses = new ObservableCollection<Address>(student.Addresses);
            StudentEnrolledCourses = student.EnrolledCourses;

        }
        catch (Exception ex)
        {

            throw new Exception($"No student found with ID: {_studentId}. {ex.Message}");
        }

    }

    [RelayCommand]
    private async Task Save()
    {
        Student student = _studentFactory!.Create
       (
           FirstNameOfStudent,
           LastNameOfStudent,
           PhoneNumberOfStudent,
           StudentAddresses.ToList(),
           EmailOfStudent,
           StudentEnrolledCourses
      )
     ;

        await _studentService!.Update(student, _studentId);
    }

    [RelayCommand]
    private void AddAddress()
    {
        StudentAddresses.Add(new Address
        {
            StreetAddress = "",
            PostalCode = 0.ToString(), // convert it to string rather then try to force user to input in a certain way
            City = ""
        });
    }

    [RelayCommand]
    private void RemoveAddress(Address address)
    {
        StudentAddresses.Remove(address);
    }
}
