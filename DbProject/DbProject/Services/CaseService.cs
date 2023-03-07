using DbProject.Context;
using DbProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Services
{
    public class CaseService
    {
        private DataContext _context = new DataContext();

        public async Task CreateCase()
        {
            var newCase = new CaseEntity();

            Console.WriteLine("Content: ");
            newCase.Content = Console.ReadLine() ?? "";

            Console.WriteLine("Comment: ");
            newCase.Comment = Console.ReadLine() ?? "";

            Console.WriteLine("Customer emailaddress: ");
            string emailAdress = Console.ReadLine();

            CustomerEntity customer  = await _context.Customers.FirstOrDefaultAsync(x => x.Email == emailAdress);

            if (customer == null)
            {
                Console.WriteLine("There is no Customer with this Emailaddress. Case not saved.");
                return;
            }

            newCase.Customer = customer;

            await SaveNewCaseToDb(newCase);


        }
        public async Task SaveNewCaseToDb(CaseEntity newCase)
        {
            _context.Cases.Add(newCase);
            var respone = await _context.SaveChangesAsync();
        }

    }
}

