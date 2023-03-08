using DbProject.Context;
using DbProject.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Services
{
    public class CustomerService
    {
        private  DataContext _context = new DataContext();

        public async Task CreateCustomer()
        {
            var customer = new CustomerEntity();

            Console.WriteLine("Firstname: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.WriteLine("Lastname: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.WriteLine("Email: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.WriteLine("Phonenumber: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            var AddressService = new AddressService();
            await AddressService.AddCustomerAddress(customer);

            await SaveCustomerToDb(customer);

            Console.WriteLine($"{customer.FirstName} has been saved.");

        }
        public async Task SaveCustomerToDb(CustomerEntity customer)
        {
            _context.Customers.Add(customer);
            var respone = await _context.SaveChangesAsync();
        }

    }
}
