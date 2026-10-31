using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedStudentViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb>? _studentService;

    [ObservableProperty]
    public partial Student? Student { get; set; }

    public ExpandedStudentViewModel()
    {

    }

    public ExpandedStudentViewModel(string studentId, IService<Student, StudentRestDb> studentService)
    {
        _studentService = studentService;
        Init(studentId);
    }

    private async void Init(string id)
    {
        await LoadStudent(id);
    }

    private async Task LoadStudent(string id)
    {
        try
        {
            Student = await _studentService!.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
