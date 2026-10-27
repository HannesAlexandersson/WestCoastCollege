using System;
using WestCoastCollege.Enums;
using WestCoastCollege.ViewModels;

namespace WestCoastCollege.Interfaces;

public interface IPageViewFactory // the interface only job is to return the correct viewmodel
{
    ViewModelBase LoadPageViewModel(PageViewsEnum pageName); // load the pageviewmodel with the enum with correct pagename
}
