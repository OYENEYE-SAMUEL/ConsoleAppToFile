using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminngToFile.Service;
using ConsoleAppFishFarminngToFile.Service.Interface;

namespace ConsoleAppFishFarminngToFile.Menu
{
    public class AdminBoard
    {
        FarmDirectorBoard farmDirectorBoard = new FarmDirectorBoard();
        IFarmDirectorService farmDirectorService = new FarmDirectorService();
        ICustomerService customerService = new CustomerService();
        IOrderService orderService = new OrderService();
        public void AdminMenu()
        {
             bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("================ Welcome to Admin Dashboard ===================");
                Console.WriteLine("1: Register Manager\n 2: View all Manager");
                Console.WriteLine("3: Remove Manager");
                Console.WriteLine("4: View all Customers");
                Console.WriteLine("5: Remove Customer");
                Console.WriteLine("6: View all orders");
                Console.WriteLine("7: to Main Menu");
                Console.WriteLine("8: Logout");
                Console.WriteLine("====================\n =============");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        farmDirectorBoard.RegisterFarmManagerMenu();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 2:
                        farmDirectorService.ViewAllManagers();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 3:
                        Console.WriteLine("Enter Manager's email");
                        string email = Console.ReadLine();
                        farmDirectorService.DeleteManager(email);
                        Console.WriteLine("================== Deleted successfully ============= ");
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 4:
                        customerService.ViewAllCustomers();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 5:

                        Console.WriteLine("Kindly provide the Customer's tag number: ");
                        string tagNumber = Console.ReadLine();
                        customerService.DeleteCustomer(tagNumber);
                     
                        Console.WriteLine();

                        AdminMenu();
                        break;

                    case 6:
                        orderService.ViewAllOrders();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 7:
                     MainMenu mainMenu = new MainMenu();
                        mainMenu.Menu();
                        break;

                    case 8:
                        Console.WriteLine("Logged out successfully");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input, kindly select from the options");
                        break;
                }
 
        }  
                   }
    }
}