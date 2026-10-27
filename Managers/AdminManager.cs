using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Menus;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class AdminManager : PersonnelManager<Admin>
{
    private readonly ApplicationData _data;
    private readonly IAdminFactory _adminFactory;
    public AdminManager(ApplicationData data, IAdminFactory adminFactory) : base(data) // base refers to the parent class, in this case the PersonnelManager
    {
        _data = data;
        _adminFactory = adminFactory;
    }

    public void AddNewAdmin()
    {
        var adminPersonalProps = AddNewPersonnel("Admin");
        var adminsAccessLevel = Helper.SetPersonellsAccessLevel();
        var isNewAdminSuperAdmin = Helper.SetIsSuperAdmin();
        var admin = _adminFactory.Create(
             adminPersonalProps.DateOfEmployment,
        adminPersonalProps.OfficeLocation,
        adminPersonalProps.FirstName,
        adminPersonalProps.LastName,
        adminPersonalProps.PhoneNumber,
        adminPersonalProps.Addresses,
        adminPersonalProps.Email,
        adminPersonalProps.SubjectFields, // again, makes no sence to me but the assignment is very clear about this. They should have EVRYTHING an teacher has...
        adminPersonalProps.TeachingCourses, // again, makes no sence to me but the assignment is very clear about this. They should have EVRYTHING an teacher has...
        adminPersonalProps.TeacherId,
        adminsAccessLevel,
isNewAdminSuperAdmin
        );

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Record created, press any key to add the new admin to the payrolls...");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please wait while the system adds the new admin to the database...");
        Thread.Sleep(550);
        Console.WriteLine("...");
        Thread.Sleep(550);
        // check for if student already exists in list
        if (Helper.CheckForDuplicates(_data.Admins, admin))
        {
            Console.WriteLine("ERROR!!! The Admin you are trying to add does already exists in the rolls! Press any key to abort and return to menu...");
            Console.ReadLine();
            return;
        }
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("...Connecting to database...");
        Thread.Sleep(550);
        Console.Clear();
        Helper.SimulateInsertToDb(admin.FirstName, admin.LastName);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        _data.Admins.Add(admin);
        DatabaseHandler.SaveList("admins.json", _data.Admins);
        Console.WriteLine("Operation Succesful!!!");
        Thread.Sleep(550);
        Menu.ReturnToMenu();
    }
}
