using WestCoastCollege.Enums;
using WestCoastCollege.ViewModels;

namespace WestCoastCollege.Interfaces;

public interface IPageViewFactory
{
    ViewModelBase LoadPageViewModel(PageViewsEnum pageName);
}
