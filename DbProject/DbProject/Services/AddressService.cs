﻿using DbProject.Context;
using DbProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Services
{
    public class AddressService
    {
        private DataContext _context = new DataContext();

        public async Task <Guid> AddCustomerAddress(CustomerEntity customer)
        {
            var address = new AddressEntity();

            Console.WriteLine("StreetName: ");
            address.StreetName = Console.ReadLine() ?? "";

            Console.WriteLine("City: ");
            address.City = Console.ReadLine() ?? "";

            Console.WriteLine("PostalCode: ");
            address.PostalCode = Console.ReadLine() ?? "";

            await AddAddressToDb(address);

            return address.Id;

            
    }
        public async Task AddAddressToDb(AddressEntity address)
        {
            _context.Address.Add(address);
            var response = await _context.SaveChangesAsync();
        }

    }
}

