using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedTeacherViewModel : ViewModelBase, IInitializableViewModel
{
    private readonly IService<Teacher, TeacherRestDb>? _teacherService;
    private string _teacherId = string.Empty;

    [ObservableProperty]
    public partial Teacher? Teacher { get; set; }

    public ExpandedTeacherViewModel()
    {

    }

    public ExpandedTeacherViewModel(IService<Teacher, TeacherRestDb> serivce)
    {
        _teacherService = serivce;
    }

    public async Task Init(string id)
    {

        _teacherId = id;
        await LoadTeacher();

    }
    private async Task LoadTeacher()
    {
        try
        {
            Teacher = await _teacherService!.Find(_teacherId);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
