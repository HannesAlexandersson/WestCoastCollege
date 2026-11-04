using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;

namespace WestCoastCollege.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb>? _studentService;
    private readonly MainWindowViewModel? _mainWindowVm;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    [ObservableProperty]
    public partial Student? SelectedStudent { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];


    public StudentsViewModel()
    {
        PageTitle = "Students";
    }
    public StudentsViewModel(IService<Student, StudentRestDb> service, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Students";
        _studentService = service;
        _mainWindowVm = mainWindowVm;
        Init();
    }

    [RelayCommand]
    public async Task Delete(string id)
    {
        try
        {
            StudentRestDb student = await _studentService!.Find(id);
            if (student is not null)
            {
                await _studentService.Delete(student._id);
                await LoadStudents();
            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    public void ShowPopUp(string studentId)
    {
        _mainWindowVm!.IsBusy = true;
        SelectedStudent = Students.FirstOrDefault(s => s.StudentId == studentId);
        if (SelectedStudent is not null)
        {
            ShowDialog = true;
        }

    }
    [RelayCommand]
    private async Task Confirm()
    {
        if (SelectedStudent is null)
            return;

        try
        {
            await Delete(SelectedStudent.StudentId);
            ShowDialog = false;
            SelectedStudent = null;
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


    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        try
        {
            Students = new ObservableCollection<Student>(await _studentService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
