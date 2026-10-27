using CommunityToolkit.Mvvm.ComponentModel;

namespace WestCoastCollege.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial string PageTitle { get; set; } = "";
}
