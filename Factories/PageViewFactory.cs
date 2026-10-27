using System;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.ViewModels;
namespace WestCoastCollege.Factories;

public class PageViewFactory : IPageViewFactory
{

    public ViewModelBase LoadPageViewModel(PageViewsEnum pageName)
    {
        return pageName switch
        {
            PageViewsEnum.Home => new HomeViewModel(),

            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };

    }

}