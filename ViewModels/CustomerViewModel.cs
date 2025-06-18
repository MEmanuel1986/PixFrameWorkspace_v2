using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using PixFrameWorkspace.Services;
using PixFrameWorkspace.Models;

namespace PixFrameWorkspace.ViewModels
{
    public partial class CustomerViewModel : ObservableObject
    {
        private readonly CustomerService _customerService;

        [ObservableProperty]
        private string _ID = string.Empty;

        [ObservableProperty]
        private string _salutation = string.Empty;

        [ObservableProperty]
        private string _titel = string.Empty;

        [ObservableProperty]
        private string _firstName = string.Empty;

        [ObservableProperty]
        private string _lastName = string.Empty;

        [ObservableProperty]
        private string _address = string.Empty;

        [ObservableProperty]
        private string _postalCode = string.Empty;

        [ObservableProperty]
        private string _city = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string _phone = string.Empty;

        [ObservableProperty]
        private string _folder = string.Empty;

        public ObservableCollection<Customer> Customers { get; } = new();

        public CustomerViewModel(CustomerService customerService)
        {
            _customerService = customerService;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            Customers.Clear();

            foreach (var customer in _customerService.GetAllCustomers())
            {
                Customers.Add(customer);
            }
        }

        [RelayCommand]
        private void AddCustomer()
        {
            var customer = new Customer
            {
                Salutation = Salutation,
                Titel = Titel,
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                PostalCode = PostalCode,
                City = City,
                Email = Email,
                Phone = Phone,
                Folder = Folder
            };

            _customerService.SaveCustomer(customer);
            Customers.Add(customer);
            ClearForm();
        }

        [RelayCommand]
        private void RemoveCustomer(Customer customer)
        {
            _customerService.DeleteCustomer(customer);
            Customers.Remove(customer);
        }

        private void ClearForm()
        {
            Salutation = string.Empty;
            Titel = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Folder = string.Empty;
        }
    }
}