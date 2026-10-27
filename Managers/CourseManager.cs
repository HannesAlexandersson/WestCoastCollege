using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Enums;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Menus;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class CourseManager
{
    private readonly ApplicationData _data; // the manager now recives the shared object rather then individual lists 
    private readonly ICourseFactory _courseFactory;


    public CourseManager(ApplicationData data, ICourseFactory courseFactory)
    {
        _data = data;
        _courseFactory = courseFactory;
    }

    public void ListAllCourses()
    {
        int counter = 0;
        foreach (var course in _data.Courses)
        {
            counter++;
            Console.WriteLine($"\e[0;34m{counter}. {course.Title} =>   \e[0;33m{course.CourseType} \e[0m");  // Display all courses with name and type (classroom or ditance)
        }

    }

    public void ListAllCoursesSorted(CourseTypeEnum courseType)
    {
        int counter = 0;
        foreach (var course in _data.Courses)
        {

            if (course.CourseType == courseType)
            {
                counter++;
                Console.WriteLine($"\e[0;34m{counter}. {course.Title} =>   \e[0;33m{course.CourseType} \e[0m");
            }
            else
            {
                continue;
            }
        }

    }
    public void ListCoursesLength()
    {
        int counter = 0;
        foreach (var course in _data.Courses)
        {
            counter++;
            Console.WriteLine($"\e[0;34m{counter}. {course.Title} =>   \e[0;33m{course.CourseLength} \e[0m");
        }
    }

    public void AddNewCourse()
    {
        string title = Helper.PromptUserForStringInput("Enter Title of course: ");
        int courseLngth = Helper.PromptUserForIntInput("Enter length of course in weeks: ");
        DateTime strtDate = Helper.PromptUserForDateInput("Enter the startdate: "); // in real production level I would here add checks for plausability! for example check that the dates correspondes with the inputted öength of the cours
        DateTime endDate = Helper.PromptUserForDateInput("Enter the enddate: ");
        Guid[] teacherId = Helper.SelectTeacher(_data.Teachers);
        CourseTypeEnum courseType = Helper.PromptForCourseType();
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        bool allFieldsCorrect = false;
        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            title = Helper.ValidateStringInput("Title", title);
            Console.Clear();
            courseLngth = Helper.ValidateIntInput("Course Length", courseLngth);
            Console.Clear();
            strtDate = Helper.ValidateDateInput("Start Date", strtDate);
            Console.Clear();
            endDate = Helper.ValidateDateInput("End Date", endDate);
            Console.Clear();
            if (Helper.ValidateCourseType("Course type", courseType))
            {
                courseType = Helper.PromptForCourseType();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("NEW COURSE FIELDS: ");
            Console.WriteLine($"{title}");
            Console.WriteLine($"{courseLngth} weeks");
            Console.WriteLine($"{strtDate} - {endDate}");
            Console.WriteLine($"Course type: {courseType}");
            allFieldsCorrect = Helper.ConfirmInput(); // confirm all input
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to start the process of adding the course to the system database...");
        Console.ReadKey();
        Thread.Sleep(550);
        Console.WriteLine("Please wait while the system adds the course to the database...");
        Thread.Sleep(550);
        // use the factory to create the new course
        Course newCourse = _courseFactory.Create(
            title,
            courseLngth,
            strtDate,
            endDate,
            teacherId,
            courseType);

        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        _data.Courses.Add(newCourse);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("courses.json", _data.Courses);
        Console.WriteLine($"{newCourse.Title} added to the rolls in the database!");
        Menu.ReturnToMenu();
    }
}
