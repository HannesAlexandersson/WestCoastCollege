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
    private readonly MainWindowViewModel? _mainWindowVm;

    [ObservableProperty]
    public partial ObservableCollection<Admin> Admins { get; set; } = [];
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    public AdminsViewModel()
    {

    }
    public AdminsViewModel(IService<Admin, AdminRestDb> service, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Admins";
        _adminServices = service;
        _mainWindowVm = mainWindowVm;
        Init();
    }
    private async void Init()
    {
        await LoadTeachers();
    }
    [RelayCommand]
    public void ShowPopUp()
    {
        _mainWindowVm!.IsBusy = true;
        ShowDialog = true;
    }
    [RelayCommand]
    public async Task Delete(string id)
    {

        _mainWindowVm!.IsBusy = true;
        ShowDialog = true;

    }

    [RelayCommand]
    private async Task Confirm()
    {
        ShowDialog = false;

        _mainWindowVm!.IsBusy = false;
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
