using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Utils;
using WestCoastCollege.Factories;
using WestCoastCollege.Enums;

namespace WestCoastCollege.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory _factory;
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

            _ => PageViewsEnum.Home
        };

        BackButtonText = BackPage switch
        {
            PageViewsEnum.Students => "Back to Students",
            _ => "Go Home"
        };
    }

    [RelayCommand]
    private void GoBack()
    {
        _currentPage = BackPage;
        CurrentView = _factory.LoadPageViewModel(BackPage);

        UpdateBackButton();
    }

    [RelayCommand]
    private void GoTo(PageViewsEnum destination)
    {
        _currentPage = destination;
        UpdateBackButton();
        CurrentView = _factory.LoadPageViewModel(destination);
    }
    [RelayCommand]
    private void GoToEditStudent(string studentId) // since it doesnt let me overload I need specefic methods when i need stuff like id's
    {
        _currentPage = PageViewsEnum.EditStudent;
        UpdateBackButton();

        CurrentView = _factory.LoadPageViewModel(
            PageViewsEnum.EditStudent, studentId);
    }

    [RelayCommand]
    private void GoToStudent(string studentId)
    {
        _currentPage = PageViewsEnum.GoToStudent;
        UpdateBackButton();

        CurrentView = _factory.LoadPageViewModel(
            PageViewsEnum.GoToStudent, studentId);
    }
}
