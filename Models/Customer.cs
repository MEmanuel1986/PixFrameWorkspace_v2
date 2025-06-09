using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixFrameWorkspace;
using PixFrameWorkspace.Services;

namespace PixFrameWorkspace.Models
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Salutation { get; set; } = string.Empty;
        public string Titel { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Folder { get; set; } = string.Empty;

        public override string ToString() =>
            $"{Id};{Salutation};{Titel};{FirstName};{LastName};{Address};{PostalCode};{City};{Email};{Phone};{Folder}";

        public static Customer FromString(string data)
        {
            var parts = data.Split(';');
            return new Customer
            {
                Id = parts[0],
                Salutation = parts[1],
                Titel = parts[2],
                FirstName = parts[3],
                LastName = parts[4],
                Address = parts[5],
                PostalCode = parts[6],
                City = parts[7],
                Email = parts[8],
                Phone = parts[9],
                Folder = parts[10]
            };
        }
    }
}
