using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastCollege.Classes;
using WestCoastCollege.Interfaces;
using WestCoastCollege.Models;
using WestCoastCollege.RestDbModels;

namespace WestCoastCollege.ViewModels;

public partial class EditAdminViewModel : ViewModelBase
{
    private readonly IService<Admin, AdminRestDb>? _adminService;
    private string _adminId = string.Empty;
    private readonly IAdminFactory? _adminFactory;
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
    //TODO add the admin propertys as fields

    public EditAdminViewModel()
    {
        PageTitle = "Edit a teacher info";
    }
    public EditAdminViewModel(IService<Admin, AdminRestDb> service, IAdminFactory factory)
    {
        PageTitle = "Edit a adin info";
        _adminService = service;
        _adminFactory = factory;
    }

    public async Task Init(string id)
    {
        _adminId = id;
        await GetAdmin();
    }

    private async Task GetAdmin()
    {
        try
        {
            var admin = await _adminService!.Find(_adminId);

            PersonellId = admin.PersonellId.ToString();
            FirstNameOfHandler = admin.FirstName;
            LastNameOfHandler = admin.LastName;
            PhoneNumberOfHandler = admin.PhoneNumber;
            EmailOfHandler = admin.Email ?? ""; // email is allowed to be null/empty string
            HandlerAddresses = new ObservableCollection<Address>(admin.Addresses);
        }
        catch (Exception ex)
        {

            throw new Exception($"No teacher found with ID: {_adminId}. {ex.Message}");
        }

    }

    [RelayCommand]
    private void AddAddress()
    {
        /* AdminAddresses.Add(new Address
        {
            StreetAddress = "",
            PostalCode = 0.ToString(),
            City = ""
        }); */
    }

    [RelayCommand]
    private void RemoveAddress(Address address)
    {
        /* AdminAddresses.Remove(address); */
    }
    /*   [RelayCommand]
     private async Task Save()
     {
         Admin admin = _adminFactory!.Create(
         dateofemplouyment
         officeloacation

             FirstNameOfTeacher,
             LastNameOfTeacher,
             PhoneNumberOfTeacher,
             TeacherAddresses.ToList(),
             EmailOfTeacher,
             personellId
             TeacherSubjectFields.ToArray()
             accesslevel
             issuperadmin
         );

         await _adminService!.Update(admin, _adminId);
     } */
}
