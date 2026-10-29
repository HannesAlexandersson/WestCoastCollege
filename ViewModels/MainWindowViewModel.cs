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
    private void GoTo(PageViewsEnum destination)
    {
        Console.WriteLine("You pressed: " + destination);
        CurrentView = _factory.LoadPageViewModel(destination); // insteead of having 6 different "goto" methods with command decoration
    }
}
