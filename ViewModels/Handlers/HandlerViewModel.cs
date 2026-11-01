using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class HandlerViewModel : ViewModelBase
{
    private readonly IService<Handler, HandlerRestDb>? _handlerService;
    [ObservableProperty]
    public partial Handler? SelectedHandler { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Handler> Handlers { get; set; } = [];

    public HandlerViewModel()
    {
        PageTitle = "Teachers";
    }

    public HandlerViewModel(IService<Handler, HandlerRestDb> service)
    {
        PageTitle = "Handlers";
        _handlerService = service;
        Init();
    }

    private async void Init()
    {
        await LoadHandlers();
    }

    [RelayCommand]
    public async Task Delete(string id)
    {
        try
        {
            HandlerRestDb handler = await _handlerService!.Find(id);
            if (handler is not null)
            {
                await _handlerService!.Delete(handler._id);
                await LoadHandlers();
            }
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
        }
    }

    private async Task LoadHandlers()
    {
        try
        {
            Handlers = new ObservableCollection<Handler>(await _handlerService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
