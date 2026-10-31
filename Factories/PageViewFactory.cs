using System;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Services;
using WestCoastCollege.ViewModels;
namespace WestCoastCollege.Factories;

public class PageViewFactory : IPageViewFactory
{

    private readonly Func<PageViewsEnum, ViewModelBase> _pageFactory; //func is an anon function
    public PageViewFactory(Func<PageViewsEnum, ViewModelBase> pageFactory)
    {
        _pageFactory = pageFactory; // we place the anon function in the private field _pageFacotry
    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum pageName)
    {
        // we call the anon function from the field pagefactory
        return _pageFactory.Invoke(pageName); // invoke basicly means "run the method", this method we call returns a viewmodelbase object (a vm)
    }
}

