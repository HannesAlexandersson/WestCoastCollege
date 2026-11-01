using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Classes;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;
using System.Linq;

namespace WestCoastCollege.ViewModels;

public partial class EditHandlerViewModel : ViewModelBase
{
    private readonly IService<Handler, HandlerRestDb>? _handlerService;
    private string _handlerId = string.Empty;
    private readonly IHandlerFactory? _handlerFactory;

    [ObservableProperty]
    private ObservableCollection<Handler> _handlers = [];

    [ObservableProperty]
    public partial string PersonellId { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string FirstNameOfHandler { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string LastNameOfHandler { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string PhoneNumberOfHandler { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string EmailOfHandler { get; set; } = string.Empty;

    [ObservableProperty]
    public partial ObservableCollection<Address> HandlerAddresses { get; set; } = [];

    public EditHandlerViewModel()
    {
        PageTitle = "Edit a handler info";
    }

    public EditHandlerViewModel(IService<Handler, HandlerRestDb> service, IHandlerFactory factory)
    {
        PageTitle = "Edit a handler info";
        _handlerService = service;
        _handlerFactory = factory;
    }

    public async Task Init(string id)
    {
        _handlerId = id;
        await GetHandler();
    }

    private async Task GetHandler()
    {
        try
        {
            var handler = await _handlerService!.Find(_handlerId);

            PersonellId = handler.PersonellId.ToString();
            FirstNameOfHandler = handler.FirstName;
            LastNameOfHandler = handler.LastName;
            PhoneNumberOfHandler = handler.PhoneNumber;
            EmailOfHandler = handler.Email ?? ""; // email is allowed to be null/empty string
            HandlerAddresses = new ObservableCollection<Address>(handler.Addresses);
            /*  TeacherSubjectFields = new ObservableCollection<FieldOfKnowledge>(handler.SubjectFields); */
        }
        catch (Exception ex)
        {

            throw new Exception($"No teacher found with ID: {_handlerId}. {ex.Message}");
        }

    }

    [RelayCommand]
    private void AddAddress()
    {
        HandlerAddresses.Add(new Address
        {
            StreetAddress = "",
            PostalCode = 0.ToString(),
            City = ""
        });
    }

    [RelayCommand]
    private void RemoveAddress(Address address)
    {
        HandlerAddresses.Remove(address);
    }

    [RelayCommand]
    private async Task Save()
    { //TODO fix the models of admins and handlers, remove unwatned proeprtys like subjectfields etc
        /*      Handler handler = _handlerFactory!.Create(
                 // dateof emplouyment,
                 //officelocation,
                 FirstNameOfHandler,
                 LastNameOfHandler,
                 PhoneNumberOfHandler,
                 HandlerAddresses.ToList(),
                 EmailOfHandler
             //handlingcourses,
             // access level enum
             );

             await _handlerService!.Update(handler, _handlerId); */
    }
}
