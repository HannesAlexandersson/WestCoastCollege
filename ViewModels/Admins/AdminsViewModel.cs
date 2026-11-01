using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class AdminsViewModel : ViewModelBase
{
    private readonly IService<Admin, AdminRestDb>? _adminServices;
    [ObservableProperty]
    public partial Admin? SelectedAdmin { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Admin> Admins { get; set; } = [];

    public AdminsViewModel()
    {

    }
    public AdminsViewModel(IService<Admin, AdminRestDb> service)
    {
        PageTitle = "Admins";
        _adminServices = service;
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
            AdminRestDb admin = await _adminServices!.Find(id);
            if (admin is not null)
            {
                await _adminServices!.Delete(admin._id);
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
            Admins = new ObservableCollection<Admin>(await _adminServices!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
