using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Utils;
using WestCoastCollege.Factories;
using WestCoastCollege.Enums;
using WestCoastCollege.Models;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Classes;
using System.Threading.Tasks;

namespace WestCoastCollege.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory? _factory;
    private PageViewsEnum _currentPage = PageViewsEnum.Home;
    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    [ObservableProperty]
    public partial PageViewsEnum BackPage { get; set; } = PageViewsEnum.Home; // used to keep track of what view the user came from so the "back" btn can be dynamic

    [ObservableProperty]
    public partial string BackButtonText { get; set; } = "Go Home"; // used to keep track of what view the user came from so the "back" btn can be dynamic
    [ObservableProperty]
    public partial bool IsBusy { get; set; }
    public MainWindowViewModel() { }

    public MainWindowViewModel(PageViewFactory factory)
    {
        _factory = factory;
        GoTo(PageViewsEnum.Home);
    }
    private void UpdateBackButton()
    {
        // if current page is for ex gotostudent, editstudent then backpage gets set to students, 
        BackPage = _currentPage switch
        {
            PageViewsEnum.GoToStudent or
            PageViewsEnum.AddNewStudent or
            PageViewsEnum.EditStudent => PageViewsEnum.Students,

            PageViewsEnum.GoToCourse or
            PageViewsEnum.AddNewCourse or
            PageViewsEnum.EditCourse => PageViewsEnum.Courses,

            PageViewsEnum.GoToTeacher or
            PageViewsEnum.AddNewTeacher or
            PageViewsEnum.EditTeacher => PageViewsEnum.Teachers,

            PageViewsEnum.GoToHandler => PageViewsEnum.Handlers,

            PageViewsEnum.GoToAdmin => PageViewsEnum.Admins,

            _ => PageViewsEnum.Home
        };

        BackButtonText = BackPage switch
        {
            PageViewsEnum.Students => "Go back to Students",
            PageViewsEnum.Courses => "Go back to Courses",
            PageViewsEnum.Teachers => "Go back to Teachers",
            PageViewsEnum.Handlers => "Go back to Handlers",
            PageViewsEnum.Admins => "Go back to Admins",
            _ => "Go to Home"
        };
    }

    [RelayCommand]
    private void GoBack()
    {
        _currentPage = BackPage;
        CurrentView = _factory!.LoadPageViewModel(BackPage);

        UpdateBackButton();
    }

    [RelayCommand]
    private void GoTo(PageViewsEnum destination)
    {
        _currentPage = destination;
        UpdateBackButton();
        CurrentView = _factory!.LoadPageViewModel(destination);
    }

    [RelayCommand]
    private async Task GoToEditStudent(string studentId) // since it doesnt let me overload the GoTo method I will need specefic methods that basicly does the same thing
    {
        _currentPage = PageViewsEnum.EditStudent;
        UpdateBackButton();
        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.EditStudent);
        await ((EditStudentViewModel)CurrentView).Init(studentId); // retyp currentview thats viewmodelbase into editstudentviewmodel and call the  init metod from it and send the id there
    }

    [RelayCommand]
    private async Task GoToStudent(string studentId)
    {
        _currentPage = PageViewsEnum.GoToStudent;
        UpdateBackButton();


        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToStudent);
        await ((ExpandedStudentViewModel)CurrentView).Init(studentId);
    }
    [RelayCommand]
    private async Task GoToAddNewStudent() // cant use the generci goto since the init needs to be awaited!
    {
        _currentPage = PageViewsEnum.AddNewStudent;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.AddNewStudent);
        await ((AddNewStudentViewModel)CurrentView).Init();
    }
    [RelayCommand]
    private async Task GoToCourse(string courseId)
    {
        _currentPage = PageViewsEnum.GoToCourse;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToCourse);
        await ((ExpandedCourseViewModel)CurrentView).Init(courseId);
    }
    [RelayCommand]
    private async Task GoToEditCourse(string courseId)
    {
        _currentPage = PageViewsEnum.EditCourse;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.EditCourse);
        await ((EditCourseViewModel)CurrentView).Init(courseId);
    }
    [RelayCommand]
    private async Task GoToAddNewCourse() // cant use the generci goto since the init needs to be awaited!
    {
        _currentPage = PageViewsEnum.AddNewCourse;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.AddNewCourse);
        await ((AddNewCourseViewModel)CurrentView).Init();
    }
    [RelayCommand]
    private async Task GoToTeacher(string teacherId)
    {
        _currentPage = PageViewsEnum.GoToTeacher;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToTeacher);
        await ((ExpandedTeacherViewModel)CurrentView).Init(teacherId);
    }


    [RelayCommand]
    private async Task GoToEditTeacher(string teacherId)
    {
        _currentPage = PageViewsEnum.EditTeacher;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.EditTeacher);
        await ((EditTeacherViewModel)CurrentView).Init(teacherId);
    }
    [RelayCommand]
    private async Task GoToAddNewTeacher() // cant use the generci goto since the init needs to be awaited!
    {
        _currentPage = PageViewsEnum.AddNewTeacher;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.AddNewTeacher);

    }

    [RelayCommand]
    private async Task GoToHandler(string handlerId)
    {
        _currentPage = PageViewsEnum.GoToHandler;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToHandler);
        await ((ExpandedHandlerViewModel)CurrentView).Init(handlerId);
    }


    [RelayCommand]
    private async Task GoToAdmin(string adminId)
    {
        _currentPage = PageViewsEnum.GoToAdmin;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToAdmin);
        await ((ExpandedAdminViewModel)CurrentView).Init(adminId);
    }

}
