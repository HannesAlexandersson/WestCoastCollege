using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.Services;

namespace WestCoastCollege.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IService<Student, StudentRestDb> _studentService;
    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = []; // instead of generic list and array we use ObservableCollection for auto updating the collection whenever it changes
    public StudentsViewModel() { }
    public StudentsViewModel(IService<Student, StudentRestDb> service)
    {
        PageTitle = "Products";
        _studentService = service;

        Init();
    }

    [RelayCommand]
    public void Edit(string itemNumber)
    {
        Console.WriteLine("Edit clicked" + itemNumber);
    }
    [RelayCommand]
    public async Task Delete(string id)
    {
        try
        {
            StudentRestDb student = await _studentService.Find(id);
            if (student is not null)
            {
                await _studentService.Delete(student._id);
                await LoadStudents();
            }
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
        }
    }


    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        try
        {
            Students = new ObservableCollection<Student>(await _studentService.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
