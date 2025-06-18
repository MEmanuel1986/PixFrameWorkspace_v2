using System.Collections.ObjectModel;
using System.IO;
using PixFrameWorkspace.Models;

namespace PixFrameWorkspace.Services
{
    public class CustomerService
    {
        private readonly string _filePath;
        private static readonly object _fileLock = new object();

        public CustomerService()
        {
            _filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "customers.db");
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            var customers = new ObservableCollection<Customer>();

            lock (_fileLock)
            {
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
            }

            return customers;
        }

        public void SaveCustomer(Customer customer)
        {
            var line = customer.ToString();

            lock (_fileLock)
            {
                File.AppendAllText(_filePath, line + Environment.NewLine);
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            lock (_fileLock)
            {
                if (File.Exists(_filePath))
                {
                    var lines = File.ReadAllLines(_filePath)
                        .Where(l => l != customer.ToString())
                        .ToArray();

                    File.WriteAllLines(_filePath, lines);
                }
            }
        }
    }
}