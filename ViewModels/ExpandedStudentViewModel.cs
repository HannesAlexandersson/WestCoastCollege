using System;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedStudentViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb> _studentService;

    [ObservableProperty]
    public partial Student Student { get; set; }

    public ExpandedStudentViewModel()
    {

    }

    public ExpandedStudentViewModel(string studentId, IService<Student, StudentRestDb> studentService)
    {
        _studentService = studentService;
        LoadStudent(studentId);
    }

    private async void LoadStudent(string id)
    {
        Student = await _studentService.Find(id);
    }
}
