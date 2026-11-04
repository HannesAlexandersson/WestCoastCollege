using System;
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

public partial class AddNewStudentViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb>? _studentService;
    private readonly IService<Course, CourseRestDb>? _courseService;
    private readonly IStudentFactory? _studentFactory;
    [ObservableProperty]
    private Course? _selectedCourse;
    private readonly MainWindowViewModel? _mainWindowVm;
    [ObservableProperty]
    private ObservableCollection<Course> _courses = [];

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }
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
    public AddNewStudentViewModel()
    {
        PageTitle = "Add new student ";
    }
    public AddNewStudentViewModel(IService<Student, StudentRestDb> studentService, IService<Course, CourseRestDb> courseService, IStudentFactory studentFactory, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Add new student ";
        _studentService = studentService;
        _courseService = courseService;
        _studentFactory = studentFactory;
        _mainWindowVm = mainWindowVm;
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
            PostalCode = 0.ToString(),
            City = ""
        });
    }

    [RelayCommand]
    private void RemoveAddress(Address address)
    {
        StudentAddresses.Remove(address);
    }

    [RelayCommand]
    private async Task Save()
    {
        try
        {

            //validate input??

            _mainWindowVm!.IsBusy = true;
            //validate userinput???
            Student student = _studentFactory!.Create
        (
            FirstNameOfStudent,
            LastNameOfStudent,
            PhoneNumberOfStudent,
            StudentAddresses.ToList(),
            EmailOfStudent,
            Guid.NewGuid().ToString(),
            StudentEnrolledCourses.ToList()
       );
            await _studentService!.Add(student);
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
        FirstNameOfStudent = string.Empty;
        LastNameOfStudent = string.Empty;
        PhoneNumberOfStudent = string.Empty;
        EmailOfStudent = string.Empty;
        StudentAddresses = [];
        StudentEnrolledCourses = [];
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
