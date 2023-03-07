

using DbProject.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var customerService = new CustomerService();
        var caseService = new CaseService();
        var AddressService = new AddressService();

        while (true)
        {


            Console.Clear();
            Console.WriteLine("1. Create a customer");
            Console.WriteLine("2. Create a new case");

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



            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}