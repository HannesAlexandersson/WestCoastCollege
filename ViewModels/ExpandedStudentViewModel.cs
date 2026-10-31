using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedStudentViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb>? _studentService;
    private string _studentId = string.Empty;

    [ObservableProperty]
    public partial Student? Student { get; set; }

    public ExpandedStudentViewModel()
    {

    }

    public ExpandedStudentViewModel(IService<Student, StudentRestDb> studentService)
    {
        _studentService = studentService;
    }

    public async void Init(string id)
    {
        _studentId = id;
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
