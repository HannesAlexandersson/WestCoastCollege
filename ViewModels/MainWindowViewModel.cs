using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Factories;

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
        GoToHome();
    }

    [RelayCommand]
    private void GoToHome() => CurrentView = _factory.LoadPageViewModel(Enums.PageViewsEnum.Home);
}
