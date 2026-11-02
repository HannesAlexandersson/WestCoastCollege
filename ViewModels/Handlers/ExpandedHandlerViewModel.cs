using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class ExpandedHandlerViewModel : ViewModelBase
{
    private readonly IService<Handler, HandlerRestDb>? _handlerService;
    private readonly MainWindowViewModel? _mainWindowVm;
    private string _handlerId = string.Empty;

    [ObservableProperty]
    public partial HandlerRestDb? Handler { get; set; }
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    public ExpandedHandlerViewModel()
    {

    }

    public ExpandedHandlerViewModel(IService<Handler, HandlerRestDb> service, MainWindowViewModel mainWindowVm)
    {
        _handlerService = service;
        _mainWindowVm = mainWindowVm;
    }

    public async Task Init(string id)
    {

        _handlerId = id;
        await LoadHandler();

    }
    private async Task LoadHandler()
    {
        try
        {
            Handler = await _handlerService!.Find(_handlerId);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    public void ShowPopUp()
    {
        _mainWindowVm!.IsBusy = true;
        ShowDialog = true;
    }
    [RelayCommand]
    public void Delete()
    {
        try
        {
            _mainWindowVm!.IsBusy = true;
            ShowDialog = true;
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
        }
    }

    [RelayCommand]
    private async Task Confirm()
    {
        ShowDialog = false;

        _mainWindowVm!.IsBusy = false;
    }
}
