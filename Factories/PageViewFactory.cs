using System;
using WestCoastCollege.Enums;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Services;
using WestCoastCollege.ViewModels;
namespace WestCoastCollege.Factories;

public class PageViewFactory : IPageViewFactory
{

    public ViewModelBase LoadPageViewModel(PageViewsEnum pageName)
    {
        return pageName switch
        {
            PageViewsEnum.Home => new HomeViewModel(),
            PageViewsEnum.Students => new StudentsViewModel(new StudentServices()),
            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };

    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum page, string studentId)
    {
        return page switch
        {
            PageViewsEnum.EditStudent => new EditStudentViewModel(studentId, new StudentServices()),
            PageViewsEnum.GoToStudent => new ExpandedStudentViewModel(studentId, new StudentServices()),
            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };
    }


}