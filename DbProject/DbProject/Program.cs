

using DbProject.Entities;
using DbProject.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var customerService = new CustomerService();
        var caseService = new CaseService();
        var AddressService = new AddressService();
        var commentservice = new CommentService();

        while (true)
        {


            Console.Clear();
            Console.WriteLine("Supports main manu.\n");
            Console.WriteLine("1. Create a customer.");
            Console.WriteLine("2. Create a new case.");
            Console.WriteLine("3. View case by ID.");
            Console.WriteLine("4. Update case Status.");
            Console.WriteLine("5. View all cases.");
            Console.WriteLine("6. Add comment to case (By ID).");


            Console.WriteLine("\nChoose one of the options above (1-5).");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    await customerService.CreateCustomer();
                    break;

                case "2":
                    Console.Clear();
                    await caseService.CreateCase();
                    break;

                case "3":
                    Console.Clear();
                    var caseEntity = await caseService.GetCaseById();
                    if (caseEntity == null)
                    {
                        Console.WriteLine($" There is no case with connectod to: {caseEntity.Id}");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"This case has caseId: {caseEntity.Id}");
                    Console.WriteLine($"Created: {caseEntity.Created}");
                    Console.WriteLine($"Status: {caseEntity.Status}");
                    foreach (var comment in caseEntity.Comments)
                    {
                        Console.WriteLine($" Comment: {comment.Comment}  -  Created at: {comment.Created}");
                    }
                    break;

                case "4":
                    Console.Clear();
                    await caseService.UpdateCaseStatus();
                    break;

                case "5":
                    Console.Clear();
                    await caseService.ViewAllCases();
                    break;

                case "6":
                    Console.Clear();
                    await commentservice.AddComment();
                    break;





            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}