using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixFrameWorkspace;
using PixFrameWorkspace.Models;

namespace PixFrameWorkspace.Services
{
    public class CustomerService
    {
        private readonly string _filePath;

        public CustomerService()
        {
            _filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "customers.db");
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            var customers = new ObservableCollection<Customer>();

            if (File.Exists(_filePath))
            {
                foreach (var line in File.ReadAllLines(_filePath))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        customers.Add(Customer.FromString(line));
                    }
                }
            }

            return customers;
        }

        public void SaveCustomer(Customer customer)
        {
            var line = customer.ToString();
            File.AppendAllLines(_filePath, new[] { line });
        }

        public void DeleteCustomer(Customer customer)
        {
            var lines = File.ReadAllLines(_filePath)
                .Where(l => l != customer.ToString())
                .ToArray();

            File.WriteAllLines(_filePath, lines);
        }
    }
}
