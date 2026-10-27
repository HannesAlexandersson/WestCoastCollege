using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Menus;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class TeacherManager
{
    private readonly ApplicationData _data;
    private readonly ITeacherFactory _teacherFactory;

    public TeacherManager(ApplicationData data, ITeacherFactory teacherFactory)
    {
        _data = data;
        _teacherFactory = teacherFactory;
    }

    public void AddNewTeacher()
    {
        Teacher newTeacherProps = Helper.PromptForPersonell("Teacher", _data.Courses);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a TeacherId for the teacher");
        Console.ReadKey();
        newTeacherProps.TeacherId = Helper.GenerateGuid();
        Console.WriteLine($" TeacherId created: {newTeacherProps.TeacherId}. Press any key to add {newTeacherProps.FirstName} {newTeacherProps.LastName} into the database...");
        Console.ReadKey();
        Thread.Sleep(550);
        Console.WriteLine("Please wait while the system adds the teacher to the database...");
        Teacher newTeacher = _teacherFactory.Create(
            newTeacherProps.FirstName,
            newTeacherProps.LastName,
            newTeacherProps.PhoneNumber,
            newTeacherProps.Addresses,
            newTeacherProps.Email,
            newTeacherProps.SubjectFields,
            newTeacherProps.TeachingCourses,
            newTeacherProps.TeacherId
        );
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("....Checking for duplicates...");
        // check for if student already exists in list
        if (Helper.CheckForDuplicates(_data.Teachers, newTeacher))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR!!! this teacher already exists in the rolls! Press any key to return to abort insertion...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            return;
        }
        Thread.Sleep(550);
        Console.WriteLine("...Connecting to database...");
        Thread.Sleep(550);
        // add the new teacher to the teachers list
        _data.Teachers.Add(newTeacher);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("teachers.json", _data.Teachers);
        Thread.Sleep(550);
        Console.WriteLine($"{newTeacher.FirstName} {newTeacher.LastName} added to the teacher rolls in the database!");
        Menu.ReturnToMenu();
    }
}
