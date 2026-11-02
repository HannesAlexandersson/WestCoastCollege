using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class HandlersViewModel : ViewModelBase
{
    private readonly IService<Handler, HandlerRestDb>? _handlerService;
    private readonly MainWindowViewModel? _mainWindowVm;
    [ObservableProperty]
    public partial ObservableCollection<Handler> Handlers { get; set; } = [];
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    public HandlersViewModel()
    {
        PageTitle = "Handlers";
    }

    public HandlersViewModel(IService<Handler, HandlerRestDb> service, MainWindowViewModel mainWindowVm)
    {
        PageTitle = "Handlers";
        _handlerService = service;
        _mainWindowVm = mainWindowVm;
        Init();
    }

    private async void Init()
    {
        await LoadHandlers();
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

    private async Task LoadHandlers()
    {
        try
        {
            var handlers = await _handlerService!.List();

            Handlers = new ObservableCollection<Handler>(handlers);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }


}
