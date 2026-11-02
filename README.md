# WestCoastCollege

### What is this?
This is a continuation of the WestcoastEducation app which is an assignmment for the .NET Clouddeveloper program at [IT-Högskolan](https://www.iths.se).
It's an conversion of the console app [WestCoastEducation](https://github.com/HannesAlexandersson/WestCoastEducation) into an Avalonia application. 

### What to think about
In this assignment we dont focus on all the models of the console app and instead only focus on Students, Teachers and courses. Handlers and Admins we simply leave as they are at this moment. 
This means that some of the propertys of the Admins and Handlers are non logical and in a real life production situation they would be handled, but as things are they just exists. 

### Handlers && Admins
Since the assignment says to only handle Students, Teachers and Courses, and since Michael explicitly states that doing to much is a cause for lower grades, the Handlers and Admins dont have any logic to them. 
They simply exist as space fillers atm, and the user can see them but can not interact with them. 

## How to run the app

Torun the app you need to fork or clone the repo, then run the repo from CLI like Bash 

```bash
dotnet run
```


But in order to get the app to work you'll need to take the mockdata from the folder Mockdata and import the json files into restDb. Then you'll need to create an AppSettings.json file in the root of the project,
and in that file insert from your own RestDb the ApiKey and BaseUrl: 
```json
{
    "Settings": {
        "ApiKey": "YOUR-OWN-RESTDB-API-KEY",
        "BaseUrl": "YOUR-OWN-RESTDB-URL"
    }
}
```

If this isnt done properly the app wont load any data and it will probably crash. 
