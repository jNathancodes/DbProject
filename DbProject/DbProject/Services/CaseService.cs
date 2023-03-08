﻿using Azure;
using DbProject.Context;
using DbProject.Entities;
using DbProject.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Services
{
    public class CaseService
    {
        private DataContext _context = new DataContext();
        private readonly object status;

        public async Task CreateCase()
        {
            var newCase = new CaseEntity();

            Console.WriteLine("Content: ");
            newCase.Content = Console.ReadLine() ?? "";

            Console.WriteLine("Comment: ");
            newCase.Comment = Console.ReadLine() ?? "";

            Console.WriteLine("Customer emailaddress: ");
            string emailAdress = Console.ReadLine();

            CustomerEntity customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email == emailAdress);

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



        public async Task UpdateCase()
        {


            Console.WriteLine("Enter email address of the customer you want to modify:");
            string Email = Console.ReadLine();

            CustomerEntity customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email == Email);


            if (customer == null)
            {
                Console.WriteLine($"Could not find customer with email address: {Email}");
                return;
            }

            List<CaseEntity> cases = await _context.Cases.Where(x => x.Customer.Id == customer.Id).ToListAsync();
            Console.WriteLine($"Customer {customer.Email} has {cases.Count} cases.");
            foreach (var item in cases)
            {
                Console.WriteLine($" {item.Status} {item.Id}");
            }
            Console.WriteLine("Write Id of the case you want to update.");
            var modifyCase = (Console.ReadLine());
            CaseEntity caseToUpdate = cases.FirstOrDefault(myCase => myCase.Id.Equals(modifyCase));
            if (caseToUpdate == null)
            {
                Console.WriteLine($"There is no case with this case id: {customer.Id}");
                return;
            }
            else
            {
                Console.WriteLine($"You can change Status to: 1.{Status.Inprogress} or 2.{Status.Finnished}. \nAwnser (1-2).");
                var caseUpdate = int.Parse(Console.ReadLine());
   
                switch (caseUpdate)
                {
                    case 1:
                        caseToUpdate.Status = Status.Inprogress;
                        break;
                    case 2:
                        caseToUpdate.Status = Status.Finnished;
                        break;
                    default:
                        Console.WriteLine("Status is not correct");
                        return;
                }
            }
            _context.Cases.Update(caseToUpdate);
        await _context.SaveChangesAsync();

        }
    }
}

// 1 spara svar från användaren 2 parsa svaret till int 3 switchcase på inten 4 sätt en status variable beroende på svaret 
// 5 sätt statusen på min case to update till den nya statusen. 6 skriv till databasen med hjälp av update metoden och 
// savechangesasync



