using System;
using WestCoastEducation.Classes;

using WestCoastEducation.Interfaces;
using WestCoastEducation.Menus;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class HandlerManager : PersonnelManager<Handler>
{
    private readonly ApplicationData _data;
    private readonly IHandlerFactory _handlerFactory;

    public HandlerManager(ApplicationData data, IHandlerFactory handlerFactory) : base(data)
    {
        _data = data;
        _handlerFactory = handlerFactory;
    }

    public void AddNewHandler()
    {
        // get the shared propertys
        var adminPersonalProps = AddNewPersonnel("Handler");
        var handlerAccessLevel = Helper.SetPersonellsAccessLevel();
        var handler = _handlerFactory.Create(
        adminPersonalProps.DateOfEmployment,
        adminPersonalProps.OfficeLocation,
        adminPersonalProps.FirstName,
        adminPersonalProps.LastName,
        adminPersonalProps.PhoneNumber,
        adminPersonalProps.Addresses,
        adminPersonalProps.Email,
        adminPersonalProps.SubjectFields,
        adminPersonalProps.TeachingCourses,
        adminPersonalProps.TeacherId,
        adminPersonalProps.TeachingCourses, // this is not actually courses that the handler teaches but courses the handler is handling. it doesnt make any sence to me have the admin personall teach classes, but again the assignment says tha these types should have EVERYTHING the teachers have so my solution is to only ask for one set of courses and use that for what courses the educational leader/handler have responsibilty for
    handlerAccessLevel
    );
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Record created, press any key to add the new handler to the payrolls...");
        Console.ReadLine();

        Console.WriteLine("Please wait while the system adds the new studyhandler to the database...");
        Thread.Sleep(550);
        Console.WriteLine("...");
        Thread.Sleep(550);
        // check for if student already exists in list
        if (Helper.CheckForDuplicates(_data.Handlers, handler))
        {
            Console.WriteLine("ERROR!!! The StudyHandler you are trying to add does already exists in the rolls! Press any key to abort and return to menu...");
            Console.ReadLine();
            return;
        }
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("...Connecting to database...");
        Thread.Sleep(550);
        Console.Clear();
        Helper.SimulateInsertToDb(handler.FirstName, handler.LastName);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        _data.Handlers.Add(handler);
        DatabaseHandler.SaveList("handlers.json", _data.Handlers);
        Console.WriteLine("Operation Succesful!!!");
        Thread.Sleep(550);
        Menu.ReturnToMenu();
    }
}
