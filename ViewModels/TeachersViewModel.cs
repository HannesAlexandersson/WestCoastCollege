using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    private readonly IService<Teacher, TeacherRestDb>? _teacherService;
    [ObservableProperty]
    public partial Teacher? SelectedTeacher { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    public TeachersViewModel()
    {
        PageTitle = "Teachers";
    }

    public TeachersViewModel(IService<Teacher, TeacherRestDb> service)
    {
        PageTitle = "Teachers";
        _teacherService = service;
        Init();
    }

    private async void Init()
    {
        await LoadTeachers();
    }

    [RelayCommand]
    public async Task Delete(string id)
    {
        try
        {
            TeacherRestDb teacher = await _teacherService!.Find(id);
            if (teacher is not null)
            {
                await _teacherService!.Delete(teacher._id);
                await LoadTeachers();
            }
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
        }
    }

    private async Task LoadTeachers()
    {
        try
        {
            Teachers = new ObservableCollection<Teacher>(await _teacherService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
