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
    private readonly MainWindowViewModel? _mainWindowVm;
    private string _studentId = string.Empty;
    private string _objectId = string.Empty;
    private readonly IStudentFactory? _studentFactory;
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }
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
    public partial ObservableCollection<Course> StudentEnrolledCourses { get; set; } = [];
    public EditStudentViewModel()
    {
        PageTitle = "Edit a students data: ";
    }


    public EditStudentViewModel(IService<Student, StudentRestDb> service, IService<Course, CourseRestDb> courseService, IStudentFactory studentFactory, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Edit a students data: ";
        _studentService = service;
        _courseService = courseService;
        _studentFactory = studentFactory;
        _mainWindowVm = mainWindowVm;
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
    {
        try
        {
            var student = await _studentService!.Find(_studentId);

            if (student == null)
            {
                Console.WriteLine($"No student found with ID: {_studentId}");
                return;
            }
            _objectId = student._id;
            StudentId = student.StudentId;
            FirstNameOfStudent = student.FirstName;
            LastNameOfStudent = student.LastName;
            PhoneNumberOfStudent = student.PhoneNumber;
            EmailOfStudent = student.Email ?? "";
            StudentAddresses = new ObservableCollection<Address>(student.Addresses);
            StudentEnrolledCourses = new ObservableCollection<Course>(student.EnrolledCourses);

        }
        catch (Exception ex)
        {

            throw new Exception($"No student found with ID: {_studentId}. {ex.Message}");
        }

    }

    [RelayCommand]
    private async Task Save()
    {
        try
        {
            _mainWindowVm!.IsBusy = true;
            Student student = _studentFactory!.Create
                (
                    FirstNameOfStudent,
                    LastNameOfStudent,
                    PhoneNumberOfStudent,
                    StudentAddresses.ToList(),
                    EmailOfStudent,
                    _studentId,
                    StudentEnrolledCourses.ToList()
                );

            await _studentService!.Update(student, _objectId);

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
        FirstNameOfStudent = string.Empty;
        LastNameOfStudent = string.Empty;
        PhoneNumberOfStudent = string.Empty;
        EmailOfStudent = string.Empty;
        StudentAddresses = [];
        StudentEnrolledCourses = [];
    }
    [RelayCommand]
    private void AddCourse()
    {
        if (SelectedCourse is null)
            return;

        if (StudentEnrolledCourses.Contains(SelectedCourse))
            return;

        StudentEnrolledCourses.Add(SelectedCourse);
        SelectedCourse = null;
    }

    [RelayCommand]
    private void RemoveCourse(Course course)
    {
        StudentEnrolledCourses.Remove(course);
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
