using System;
using System.Collections.ObjectModel;
using System.Linq;
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
    private readonly MainWindowViewModel? _mainWindowVm;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }
    [ObservableProperty]
    public partial Teacher? SelectedTeacher { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    public TeachersViewModel()
    {
        PageTitle = "Teachers";
    }

    public TeachersViewModel(IService<Teacher, TeacherRestDb> service, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Teachers";
        _teacherService = service;
        _mainWindowVm = mainWindowVm;
        Init();
    }

    private async void Init()
    {
        await LoadTeachers();
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

    [RelayCommand]
    public void ShowPopUp(string teacherId)
    {
        _mainWindowVm!.IsBusy = true;
        SelectedTeacher = Teachers.FirstOrDefault(s => s.TeacherId == teacherId);
        if (SelectedTeacher is not null)
        {
            ShowDialog = true;
        }

    }
    [RelayCommand]
    private async Task Confirm()
    {
        if (SelectedTeacher is null)
            return;

        try
        {
            await Delete(SelectedTeacher.TeacherId);
            ShowDialog = false;
            SelectedTeacher = null;
            _mainWindowVm!.IsBusy = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    private void Abort()
    {
        ShowDialog = false;

        _mainWindowVm!.IsBusy = false;
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
}
