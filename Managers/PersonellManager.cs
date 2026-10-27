using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Classes;

namespace WestCoastEducation.Managers;

public class PersonnelManager<T> where T : AdminPersonel // T must inherit from AdminPersonel
{
    private readonly ApplicationData _data;

    public PersonnelManager(ApplicationData data)
    {
        _data = data;
    }

    // since pretty much all these methods does the same thing exept for names and small details i tried to make a genereic method to handle all adminpersonell
    public AdminPersonel AddNewPersonnel(string position)
    {
        var newTeacherProps = Helper.PromptForPersonell(position, _data.Courses);
        var dateOfEmployment = Helper.PromptUserForDateInput("Enter the startdate of the employment: ");
        var officeLocation = Helper.PromptForOfficeLocation();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Press any key to generate a Id for the new {position}");
        Console.ReadKey();
        newTeacherProps.TeacherId = Helper.GenerateGuid();

        Console.WriteLine($" Id created: {newTeacherProps.TeacherId}. Press any key to confirm the creation of {newTeacherProps.FirstName} {newTeacherProps.LastName} ...");
        Console.ReadKey();

        return new AdminPersonel
        {
            FirstName = newTeacherProps.FirstName,
            LastName = newTeacherProps.LastName,
            Email = newTeacherProps.Email,
            PhoneNumber = newTeacherProps.PhoneNumber,
            Addresses = newTeacherProps.Addresses,
            TeachingCourses = newTeacherProps.TeachingCourses,
            SubjectFields = newTeacherProps.SubjectFields,
            TeacherId = newTeacherProps.TeacherId,
            DateOfEmployment = dateOfEmployment,
            OfficeLocation = officeLocation
        };
    }
}
