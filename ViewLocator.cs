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

        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);// matches the view files with corresponding viewmodel, replace ViewModel with only View
        var type = Type.GetType(name); // use the viewName string, find it, load it into memory, check what type it is (presumably a class)

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;// retype to Control type, and create instance 
        }

        return new TextBlock { Text = "Page not Found: " + name }; // if nothing is found return and single textblock with the text not found
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase; // controls if the type is of the viewmodelbase type
    }
}
