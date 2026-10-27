using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using WestCoastCollege.ViewModels;

namespace WestCoastCollege;

/// <summary>
/// Given a view model, returns the corresponding view if possible.
/// </summary>
[RequiresUnreferencedCode(
    "Default implementation of ViewLocator involves reflection which may be trimmed away.",
    Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null)
            return null; // early return, return null if the incoming data is null

        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);// matches the view files with corresponding viewmodel, replace ViewModel with only View
        var type = Type.GetType(name); // use the viewName string, find it, load it into memory, check what type it is (presumably a class)
        if (type is null) return null;
        var control = (Control)Activator.CreateInstance(type)!; // retype to Control type, and create instance 
        control.DataContext = param; // set the datacontext to the data from the argument list whatever that is
        Console.WriteLine(control);
        return control;
    }

    public bool Match(object? data) => data is ViewModelBase; // controls if the type is of the viewmodelbase type
}
