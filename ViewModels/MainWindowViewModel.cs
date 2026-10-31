using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Utils;
using WestCoastCollege.Factories;
using WestCoastCollege.Enums;
using WestCoastCollege.Models;

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

    public MainWindowViewModel() { }

    public MainWindowViewModel(PageViewFactory factory)
    {
        _factory = factory;
        GoTo(PageViewsEnum.Home);
    }
    private void UpdateBackButton()
    {
        BackPage = _currentPage switch
        {
            PageViewsEnum.GoToStudent or
            PageViewsEnum.EditStudent => PageViewsEnum.Students,

            PageViewsEnum.GoToCourse or
            PageViewsEnum.EditCourse => PageViewsEnum.Courses,

            PageViewsEnum.GoToTeacher or
            PageViewsEnum.EditTeacher => PageViewsEnum.Teachers,

            PageViewsEnum.GoToHandler or
            PageViewsEnum.EditHandler => PageViewsEnum.Handlers,

            PageViewsEnum.GoToAdmin or
            PageViewsEnum.EditAdmin => PageViewsEnum.Admins,

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
    private void GoToEditStudent(string studentId) // since it doesnt let me overload the GoTo method I will need specefic methods that basicly does the same thing
    {
        _currentPage = PageViewsEnum.EditStudent;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.EditStudent);
        ((EditStudentViewModel)CurrentView).Init(studentId); // retyp currentview thats viewmodelbase into editstudentviewmodel and call the  init metod from it and send the id there
    }

    [RelayCommand]
    private void GoToStudent(string studentId)
    {
        _currentPage = PageViewsEnum.GoToStudent;
        UpdateBackButton();


        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToStudent);
        ((ExpandedStudentViewModel)CurrentView).Init(studentId);
    }
    [RelayCommand]
    private void GoToCourse(string courseId)
    {
        _currentPage = PageViewsEnum.GoToCourse;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.GoToCourse);
        ((ExpandedCourseViewModel)CurrentView).Init(courseId);
    }
    [RelayCommand]
    private void GoToEditCourse(string courseId)
    {
        _currentPage = PageViewsEnum.EditCourse;
        UpdateBackButton();

        CurrentView = _factory!.LoadPageViewModel(PageViewsEnum.EditCourse);
        ((EditCourseViewModel)CurrentView).Init(courseId);
    }
}
