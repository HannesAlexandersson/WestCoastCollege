using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using WestCoastCollege.Classes;
using WestCoastCollege.Enums;
using WestCoastCollege.Models;

namespace WestCoastCollege.Utils;

public class Helper
{
    public static bool SetIsSuperAdmin()
    {
        Console.Clear();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Is this admin a superadmin? (yes/no)");

            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please enter yes or no...");
                Console.ResetColor();
            }
            else if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (userInput.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please enter yes or no...");
                Console.ResetColor();
            }
        }
    }
    public static AccessLevelEnum SetPersonellsAccessLevel()
    {
        Console.Clear();

        Console.CursorVisible = true;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Select an access level:");
            Console.WriteLine("none for personell that should'nt access classified data.");
            Console.WriteLine("basic for personell that can handle basic personal data of students.");
            Console.WriteLine("super for personall with full access and clearence");

            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please select a valid access level...");
                Console.ResetColor();
            }
            else if (Enum.TryParse(userInput, true, out AccessLevelEnum result)
                     && Enum.IsDefined(typeof(AccessLevelEnum), result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please select none, basic, or super...");
                Console.ResetColor();
            }
        }
    }
    public static string PromptUserForStringInput(string prompt)
    {
        bool incorrect = true;
        string userInput = "";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible = true;
        while (incorrect)
        {
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.Green;
            userInput = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please try again, type with the letter keys...");
                Console.ResetColor();
            }
            else
            {
                incorrect = false;
            }
        }
        return userInput;
    }
    public static int PromptUserForIntInput(string prompt)
    {
        Console.Clear();

        Console.CursorVisible = true;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please try again, ONLY use numbers...");
                Console.ResetColor();
            }
            else if (int.TryParse(userInput, out int result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please try again, ONLY use numbers...");
                Console.ResetColor();
            }
        }
    }

    public static DateTime PromptUserForDateInput(string prompt)
    {
        Console.Clear();

        Console.CursorVisible = true;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{prompt} (yyyy-MM-dd)");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty, please try again.");
                Console.ResetColor();
            }
            else if (DateTime.TryParseExact(
                         userInput,
                         "yyyy-MM-dd",
                         System.Globalization.CultureInfo.InvariantCulture,
                         System.Globalization.DateTimeStyles.None,
                         out DateTime result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date. Use the format yyyy-MM-dd, e.g. 2026-10-10.");
                Console.ResetColor();
            }
        }
    }

    public static string PromptForOfficeLocation()
    {
        bool incorrect = true;
        string userInput = "";

        while (incorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the office location (format: Floor: 2, DoorNumber: 15): ");
            Console.ForegroundColor = ConsoleColor.Green;
            userInput = Console.ReadLine()?.Trim() ?? "";

            if (System.Text.RegularExpressions.Regex.IsMatch(
                userInput,
                @"^Floor:\s*\d+,\s*DoorNumber:\s*\d+$"))
            {
                incorrect = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid format. Example: Floor: 2, DoorNumber: 15");
                Console.ResetColor();
            }
        }

        return userInput;
    }

    public static void CheckInput()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid selection. Please try again.");
        Console.ResetColor();
        Console.ReadKey();
    }

    public static Guid GenerateGuid()
    {
        Guid newGuid = Guid.NewGuid();
        return newGuid;
    }

    public static string ValidateStringInput(string nameOfInput, string input)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N' ");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return input;
            }
            else if (userInput == "n")
            {
                return PromptUserForStringInput($"Enter the {nameOfInput}");

            }
        }
    }
    public static int ValidateIntInput(string nameOfInput, int input)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N' ");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return input;
            }
            else if (userInput == "n")
            {
                return PromptUserForIntInput($"Enter the {nameOfInput}");
            }
        }
    }
    public static DateTime ValidateDateInput(string nameOfInput, DateTime input)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input:yyyy-MM-dd}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N'");

            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return input;
            }
            else if (userInput == "n")
            {
                return PromptUserForDateInput($"Enter the {nameOfInput}");
            }
        }
    }

    public static Address ValidateAddress(string nameOfInput, Address address)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}:");
            Console.WriteLine($"{address.StreetAddress}, {address.PostalCode} {address.City}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change it, press 'N'");

            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return address;
            }
            else if (userInput == "n")
            {
                address.StreetAddress = PromptUserForStringInput("Enter the street address");
                address.PostalCode = ValidateIntInput("Postal code", address.PostalCode);
                address.City = PromptUserForStringInput("Enter the city");

                return address;
            }
        }
    }

    public static void Terminate()
    {
        Environment.Exit(0);
    }

    public static bool ConfirmInput()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Is all fields correct? Y/N");
            Console.ForegroundColor = ConsoleColor.Green;
            var userCheck = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userCheck))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input value! Please answer with Y for yes or N for no!");
                Console.ResetColor();
                continue;
            }
            else if (userCheck != "y" && userCheck != "n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userCheck == "y")
            {
                return true;
            }
            else if (userCheck == "n")
            {
                return false;
            }
        }
    }

    public static Person PromptForPerson(string nameOfObject)
    {
        // map all propertys of a person to a dictonary so we can iterate each propery
        Dictionary<string, string> fields = new()
    {
        { "firstName", "" },
        { "lastName", "" },
        { "email", "" },
        { "phone", "" },
        { "address", "" },
        { "city", "" }
    };
        // iterate each property and prompt for an userinput
        foreach (var field in fields.Keys.ToList())
        {
            fields[field] = PromptUserForStringInput(
                $"Enter {nameOfObject} {field}: ");
        }

        int pCode = PromptUserForIntInput(
            $"Enter {nameOfObject} postal code: ");

        return new Person
        {
            FirstName = fields["firstName"],
            LastName = fields["lastName"],
            Email = fields["email"],
            PhoneNumber = fields["phone"],
            Addresses =
            [
                new Address
            {
                StreetAddress = fields["address"],
                PostalCode = pCode,
                City = fields["city"]
            }
            ]
        };
    }

    public static Teacher PromptForPersonell(string position, List<Course> courses) // returns a teacher since all personell extends the teacher class
    {
        var personData = PromptForPerson(position);
        FieldOfKnowledge[] subjectFields = PromptForSubjectFields();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Select the course/courses that the new {position} is handling...");
        List<Course> teachingCourses = SelectCourses(courses);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        // validate all fields
        bool allFieldsCorrect = false;
        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            foreach (var item in personData.GetType().GetProperties()) // since personData is an instance of the Person calss I cant iterate through it. So I need too retrive its properties to iterate over them
            {
                var value = item.GetValue(personData); // get the actual value of the 'item' 

                if (value is string text) // check what type the value the property is so we know what validationtype to call
                {
                    item.SetValue(personData,
                        ValidateStringInput(item.Name, text));
                }
                else if (value is int number)
                {
                    item.SetValue(personData,
                        ValidateIntInput(item.Name, number));
                }
                else if (item.Name == nameof(personData.Addresses)) // we dont want to hardcode the string to compare
                {
                    for (int i = 0; i < personData.Addresses.Count; i++)
                    {
                        personData.Addresses[i] = ValidateAddress(
                            $"Address {i + 1}",
                            personData.Addresses[i]);
                    }
                }

                Console.Clear();
            }

            for (int i = 0; i < subjectFields.Length; i++) //iterate thorugh the subjectField array and call the validation method for each iteration
            {
                subjectFields[i].NameOfSubject =
                   ValidateStringInput(
                        $"Subject field {i + 1}",
                        subjectFields[i].NameOfSubject);
                Console.Clear();
            }

            for (int i = 0; i < teachingCourses.Count; i++) // same here but with a list instead of array
            {
                teachingCourses[i].Title =
                   ValidateStringInput(
                        $"Course title {i + 1}",
                        teachingCourses[i].Title);
                Console.Clear();
            }

            Console.WriteLine($"*** NEW {position} FINAL CHECK ***");
            Console.WriteLine($"{personData.FirstName} {personData.LastName}");
            Console.WriteLine($"{personData.Addresses[0].StreetAddress} {personData.Addresses[0].PostalCode} {personData.Addresses[0].City}");
            Console.WriteLine(personData.PhoneNumber);
            Console.WriteLine(personData.Email);

            Console.WriteLine("Subject fields:");
            foreach (var subject in subjectFields)
            {
                Console.WriteLine(subject.NameOfSubject);
            }

            Console.WriteLine("Courses:");
            foreach (var course in teachingCourses)
            {
                Console.WriteLine(course.Title);
            }

            Console.WriteLine("********-----********");
            allFieldsCorrect = ConfirmInput(); // final cofimation before finalazing
        }


        return new Teacher()
        {
            FirstName = personData.FirstName,
            LastName = personData.LastName,
            Email = personData.Email,
            PhoneNumber = personData.PhoneNumber,
            Addresses = personData.Addresses,
            SubjectFields = subjectFields,
            TeachingCourses = teachingCourses.ToArray()
        };


    }

    public static FieldOfKnowledge[] PromptForSubjectFields()
    {
        List<FieldOfKnowledge> subjectFields = [];

        bool addMore = true;

        while (addMore)
        {
            string subject = PromptUserForStringInput("Enter a subject field:");

            subjectFields.Add(new FieldOfKnowledge
            {
                NameOfSubject = subject
            });

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Add more subject fields? Y/N");

                Console.ForegroundColor = ConsoleColor.Green;
                var userCheck = Console.ReadLine()?.Trim().ToLower();

                if (userCheck == "y")
                {
                    break;
                }

                if (userCheck == "n")
                {
                    addMore = false;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please answer with Y or N.");
                Console.ResetColor();
            }
        }

        return subjectFields.ToArray();
    }


    public static CourseTypeEnum PromptForCourseType()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Select the course type:");
            Console.WriteLine("1. Classroom");
            Console.WriteLine("2. Distance");

            Console.ForegroundColor = ConsoleColor.Green;
            string? input = Console.ReadLine()?.Trim();
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (input)
            {
                case "1":
                    return CourseTypeEnum.Classroom;

                case "2":
                    return CourseTypeEnum.Distance;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static Guid[] SelectTeacher(List<Teacher> teachers)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < teachers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {teachers[i].FirstName} {teachers[i].LastName}");
        }

        while (true)
        {
            Console.WriteLine("Select a teacher by number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (int.TryParse(input, out int selection) &&
                selection >= 1 &&
                selection <= teachers.Count)
            {
                return [teachers[selection - 1].TeacherId];
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    public static List<Course> SelectCourses(List<Course> courses)
    {
        List<Course> selectedCourses = [];

        Console.ForegroundColor = ConsoleColor.Cyan;

        for (int i = 0; i < courses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {courses[i].Title}");
        }

        bool selectMore = true;

        while (selectMore)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Select a course by number:");
            Console.ForegroundColor = ConsoleColor.Green;

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int selection) &&
                selection >= 1 &&
                selection <= courses.Count)
            {
                Course selectedCourse = courses[selection - 1];

                if (!selectedCourses.Contains(selectedCourse))
                {
                    selectedCourses.Add(selectedCourse);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{selectedCourse.Title} added.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Course already selected.");
                }

                while (true)
                {
                    Console.WriteLine("Add more courses? Y/N");
                    Console.ForegroundColor = ConsoleColor.Green;

                    var userCheck = Console.ReadLine()?.Trim().ToLower();

                    if (userCheck == "y")
                    {
                        break;
                    }

                    if (userCheck == "n")
                    {
                        selectMore = false;
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please answer with Y or N.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection. Please enter a valid course number.");
            }
        }

        Console.ResetColor();
        return selectedCourses;
    }

    public static bool ValidateCourseType(string nameOfInput, CourseTypeEnum input)
    {

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N' ");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
                continue;
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return false;
            }
            else if (userInput == "n")
            {
                return true;

            }
        }
    }

    public static void SimulateInsertToDb(string fName, string lName)
    {

        /*  Thread.Sleep(550);
         Console.WriteLine("Please wait while the system connects to the database...");
         Thread.Sleep(550);
         Console.WriteLine("....");
         Thread.Sleep(550);
         Console.WriteLine("Connecting to database...");
         Thread.Sleep(550);
         Console.WriteLine("....");
         Thread.Sleep(550);
         Console.WriteLine("Attempting to write to disk...");
         Thread.Sleep(550);
         Console.WriteLine("....");
         Thread.Sleep(550);
         Console.WriteLine("Writing to disk...");
         Thread.Sleep(550);
         Console.WriteLine($"{fName} {lName} added to the database!"); */
    }
    public static bool CheckForDuplicates<T>(List<T> list, T newObject) where T : class
    {
        foreach (T oldObject in list) // oldObject is the type of T IE whatever type of list we send into the methd
        {
            if (oldObject is Person existingPerson &&
            newObject is Person newPerson) // since all humanlike classes inherits from person its enough to compare the person propertys for matches
            {
                if (existingPerson.FirstName == newPerson.FirstName &&
                    existingPerson.LastName == newPerson.LastName &&
                    existingPerson.PhoneNumber == newPerson.PhoneNumber &&
                    existingPerson.Email == newPerson.Email &&
                    existingPerson.Addresses.Count > 0 &&
                    newPerson.Addresses.Count > 0 &&
                    existingPerson.Addresses[0].StreetAddress ==
                        newPerson.Addresses[0].StreetAddress &&
                    existingPerson.Addresses[0].PostalCode ==
                        newPerson.Addresses[0].PostalCode &&
                    existingPerson.Addresses[0].City ==
                        newPerson.Addresses[0].City)
                {
                    return true; // if this was a real production level application i would have seperate checks for propertys that can and cant be shared. For example it is possible that people have the same name, but it isnt possible that people have the same email or phonenumber. 
                }
            }
            if (oldObject is Course existingCourse &&
           newObject is Course newCourse)
            {
                if (existingCourse.Title == newCourse.Title &&
                    existingCourse.CourseLength == newCourse.CourseLength &&
                    existingCourse.StartDate == newCourse.StartDate &&
                    existingCourse.EndDate == newCourse.EndDate &&
                    existingCourse.CourseType == newCourse.CourseType &&
                    existingCourse.CoursePersonnelIds.Length ==
                        newCourse.CoursePersonnelIds.Length &&
                    existingCourse.CoursePersonnelIds.All(id =>
                        newCourse.CoursePersonnelIds.Contains(id)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static PageViewsEnum GetPageViewsEnum(string enumName)
    {
        return enumName switch
        {
            "home" => PageViewsEnum.Home,
            "student" => PageViewsEnum.Students,
            "teacher" => PageViewsEnum.Teachers,
            "course" => PageViewsEnum.Courses,
            "admin" => PageViewsEnum.Admins,
            "handler" => PageViewsEnum.Handlers,
            _ => throw new ArgumentException(
           $"Error when loading the page: {enumName}", nameof(enumName))
        };

    }
}