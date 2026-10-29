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
    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    public MainWindowViewModel() { }

    public MainWindowViewModel(PageViewFactory factory)
    {
        _factory = factory;
        GoTo(PageViewsEnum.Home);
    }

    [RelayCommand]
    private void GoTo(PageViewsEnum destination)// insteead of having 6 different "goto" methods with command decoration I have one generic
    {
        CurrentView = _factory.LoadPageViewModel(destination);
    }
    [RelayCommand]
    private void GoToEditStudent(string studentId) => CurrentView = _factory.LoadPageViewModel(PageViewsEnum.EditStudent, studentId);
    [RelayCommand]
    private void GoToStudent(string studentId) => CurrentView = _factory.LoadPageViewModel(PageViewsEnum.GoToStudent, studentId);
}
