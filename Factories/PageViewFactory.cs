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
            PageViewsEnum.Courses => new CoursesViewModel(new CourseServices()),
            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };

    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum page, string id)
    {
        return page switch
        {
            PageViewsEnum.EditStudent => new EditStudentViewModel(id, new StudentServices()),
            PageViewsEnum.GoToStudent => new ExpandedStudentViewModel(id, new StudentServices()),
            PageViewsEnum.EditCourse => new EditCourseViewModel(id, new CourseServices(), new CourseFactory(), new TeacherServices()),
            PageViewsEnum.GoToCourse => new ExpandedCourseViewModel(id, new CourseServices()),
            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };
    }


}