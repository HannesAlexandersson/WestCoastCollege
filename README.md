# WestCoastCollege

## How to run the app

Torun the app you need to fork or clone the repo, then run the repo from CLI like Bash 

```bash
dotnet run
```

## What you'll need

### RESTDB Data
In order to get the app to work you'll need to take the mockdata from the folder Mockdata and import the json files into restDb. 

### AppSettings.json
Then you'll need to create an AppSettings.json file in the root of the project,
and in that file insert from your own RestDb the ApiKey and BaseUrl: 
```json
{
    "Settings": {
        "ApiKey": "YOUR-OWN-RESTDB-API-KEY",
        "BaseUrl": "YOUR-OWN-RESTDB-URL"
    }
}
```
The database documents need to have the same datatypes and names as the json files.
If this isnt done properly the app wont load any data and it will probably crash. 

### What is this?
This is a continuation of the WestcoastEducation app which is an assignmment for the .NET Clouddeveloper program at [IT-Högskolan](https://www.iths.se).
It's an conversion of the console app [WestCoastEducation](https://github.com/HannesAlexandersson/WestCoastEducation) into an Avalonia application. 

### What to think about
In this assignment we dont focus on all the models of the console app and instead only focus on Students, Teachers and courses. Handlers and Admins we simply leave as they are at this moment. 
This means that some of the propertys of the Admins and Handlers are non logical and in a real life production situation they would be handled, but as things are they just exists. 

### Handlers && Admins
Since the assignment says to only handle Students, Teachers and Courses, and since Michael explicitly states that doing to much is a cause for lower grades, the Handlers and Admins dont have any logic to them. 
They simply exist as space fillers atm, and the user can see them but can not interact with them. 

## The assignment and how its completed
The assignment requires the app to be able to list all teachers, students and courses. This is achived by accessing the type you want to list in the home screen, for example students. 
This will take you to the students view that fetches all students from restDb and renders them in a list showing name and email. If you want to get access to more information about a certain student
you can press the "expand" button on the left side of the students name. This will take you to a slug page of the perticular student where ALL data is rendered. 

The same layout and principles is true for all the different types. 
### Edit an object
In both the 'list all' views, and the slug view there is a "edit" button. It's the green pen icon on the right side of the screen. Press this button to get to the edit view. Here you can edit all the data of an object like a student/course/teacher. 

### Delete an object
In both the 'list all' views, and the slug view there is a "delete" button. It's the red 'X' icon on the right side of the screen. Press this button to delete the object from the database. There is no view for deleting an object.

### Add a new object
When in the 'list all' view of any datatype, there is a "add new" button on the top left side of the screen. Press this button to get to the 'Add new' view. Here you can fill out a form to add new students/teachers and courses. 


# Grade and requirements
## For 'G'
The assignment requires the app to be able to : 
- List courses -> CHECK with the CoursesView & ViewModel
- Add courses -> CHECK with the AddCourseView and ViewModel
- Delete courses -> CHECK with the CoursesView & ViewModel
- List Students -> CHECK with the StudentsView & ViewModel
- Add Students -> CHECK with the AddStudentsView & ViewModel
- List Teachers -> CHECK with the TeachersView & ViewModel
- Add Teachers -> CHECK with the AddTeachersView & ViewModel
- Handle a teachers subjectfields - CHECK with the EditTeachersView & ViewModel

In Addition to all this, the app also needs to be utilizing MVVM and use RestDB as database -> CHECK & CHECK
Also all design and coloring must be handled as dynamic resources -> CHECK

## For 'VG'
- The app must use Dependency Injection -> CHECK
- All communication with RestDb must be divided into interface and implementation -> CHECK
- Teachers and Courses should be editable -> CHECK 


### SUMMARY
So its clear to me that all requiremnts for VG is fulfilled. All classes and types have a base view where all objects in the db of that type/class is listed. They also have an 'expanded' view
where the full information of an perticular object is rendered. In addition to this there is also a 'Edit' view and a 'Add new' view for alclasses where the user can edit and object and add new objects to the db.  
