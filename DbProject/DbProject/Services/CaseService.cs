using Azure;
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
using System.Security.Cryptography.X509Certificates;
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


        public async Task<CaseEntity> GetCaseById()
        {
            Console.WriteLine("Enter a case Id:");
            string userId = Console.ReadLine();
            Guid gUserId = new Guid(userId);


            CaseEntity caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.Id == gUserId);

            

            return caseEntity;

        }   
        public async Task UpdateCaseStatus()
        {
            CaseEntity caseToUpdate = await GetCaseById();

            if (caseToUpdate == null)
            {
                Console.WriteLine("There is no case with this ID...");
                return;
            }

            Console.WriteLine($"You can choose status between (1-3): \n1. {Status.NotStarted} \n2. {Status.Inprogress}  \n3. {Status.Finnished}");
            string status = Console.ReadLine();

            switch (status)
            {
                case "1":
                    caseToUpdate.Status = Status.NotStarted;
                    break;

                case "2":
                    caseToUpdate.Status = Status.Inprogress;
                    break;

                case "3":
                    caseToUpdate.Status = Status.Finnished;
                    break;

                default:
                    Console.WriteLine("You can only choose between (1-3)");
                    return;
            }
        
        _context.Cases.Update(caseToUpdate);
        await _context.SaveChangesAsync();
            

        }

        public async Task ViewAllCases()
        {
            List<CaseEntity> cases = await _context.Cases.Include(x => x.Comments).ToListAsync();
            if (cases == null!)
            {
                Console.WriteLine("There is no cases in the Database");
                return;
            }
            foreach ( var caseEntity in cases ) 
            {
                Console.WriteLine($" CaseId: {caseEntity.Id}  -  Case status:  {caseEntity.Status}");
                Console.WriteLine($" Content: {caseEntity.Content}");
                Console.WriteLine($" Created: {caseEntity.Created} \n");
            }
        }
    }
}





