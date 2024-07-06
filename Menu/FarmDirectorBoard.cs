using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Service;
using ConsoleAppFishFarminngToFile.Service.Implementation;
using ConsoleAppFishFarminngToFile.Service.Interface;

namespace ConsoleAppFishFarminngToFile.Menu
{
    public class FarmDirectorBoard
    {
        IFarmDirectorService farmDirectorService = new FarmDirectorService();
        IOrderService orderService = new OrderService();
        // IUserService userService = new UserService();
        ICategoryService categoryService = new CategoryService();
        IPondService pondService = new PondService();
        public void FarmManagerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------- Welcome to Manager DashBoard ----------------");
            Console.WriteLine("1: View Profile\n 2: View all orders");
            Console.WriteLine("3: To fund wallet");
            Console.WriteLine("4: To view wallet Balance");
            Console.WriteLine("5: Register category of fish");
            Console.WriteLine("6: View all available category of fish ");
            Console.WriteLine("7: Update category of fish");
            Console.WriteLine("8: Delete fish category");
            Console.WriteLine("9: Register available ponds");
            Console.WriteLine("10: View all ponds");
            Console.WriteLine("11: Update pond");
            Console.WriteLine("12: Delete Pond");
            Console.WriteLine("0: To Main Menu");
            Console.WriteLine();
            Console.WriteLine("*****************\n*********");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {

                farmDirectorService.ViewManagerProfile(UserService.LoginUser.Email);
                FarmManagerMenu();
            }
            else if (input == 2)
            {
                orderService.ViewAllOrders();
                Console.WriteLine();
                FarmManagerMenu();

            }

            else if (input == 3)
            {
                Console.WriteLine("Input the amount to deposit: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                farmDirectorService.ManagerFundWallet(UserService.LoginUser.Email, amount);
                Console.WriteLine();
                FarmManagerMenu();
            }

            else if (input == 4)
            {
                farmDirectorService.ViewWalletBalance(UserService.LoginUser.Email);
                Console.WriteLine();
                FarmManagerMenu();
            }

            else if (input == 5)
            {
                Console.Write("What is the name of the fish type: ");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What range of period: ");
                string period = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is the price of this type: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("How many quantity is available: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter name of pond: ");
                string pondName = Console.ReadLine();
                Console.WriteLine();
                var response = categoryService.Create(name, period, price, quantity, pondName);
               if(response.Status == true)
               {
                     Console.WriteLine(response.Message);
               }
               else
               {
                    Console.WriteLine(response.Message);
               }
               
                Console.WriteLine();
                FarmManagerMenu();
            }

            else if (input == 6)
            {
                categoryService.ViewAllCategory();
                Console.WriteLine();
                FarmManagerMenu();
            }

            else if (input == 7)
            {
                Console.WriteLine("Kindly enter the category id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Enter the new price: ");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("How many quantity do want to add: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var response = categoryService.Update(id, newPrice, quantity);
                Console.WriteLine(response.Message);
                Console.WriteLine();
                FarmManagerMenu();

            }
            else if (input == 8)
            {
                Console.WriteLine("Kindly enter the category id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                categoryService.DeleteCategory(id);

                Console.WriteLine();
                FarmManagerMenu();

            }
            else if (input == 9)
            {
                Console.WriteLine("Enter Pond's name: ");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Pond's description: ");
                string description = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();
                 Console.WriteLine("Enter the dimension (hint: 5x3): ");
                string dimension = Console.ReadLine();
                Console.WriteLine();
                var response = pondService.Create(UserService.LoginUser.Id, name, description, dimension);
                if (response.Status == true)
                {
                    Console.WriteLine(response.Message);
                }
               
                Console.WriteLine();
                FarmManagerMenu();

            }
            else if (input == 10)
            {
                pondService.ViewAllPonds();
                Console.WriteLine();
                FarmManagerMenu();
            }

            else if (input == 11)
            {
                Console.WriteLine("What is the tag number of the pond: ");
                string tagNumber = Console.ReadLine();
                Console.WriteLine();
                // Console.WriteLine("What is the new size of the pond");
                // int newSize = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the name of the pond");
                string giveName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Pond's description: ");
                string newDescription = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Pond's dimension: ");
                string newDimension = Console.ReadLine();
                Console.WriteLine();
                var response = pondService.UpdatePond(tagNumber, giveName, newDescription, newDimension);
                if (response.Status == true)
                {
                    Console.WriteLine(response.Message);
                }
                // Console.WriteLine();
                Console.WriteLine();
                FarmManagerMenu();

            }
            else if (input == 12)
            {
                Console.WriteLine("What is the tag Number of the pond");
                string tagNumber = Console.ReadLine();
                Console.WriteLine();
                var response = pondService.DeletePond(tagNumber);
                if (response.Status == true)
                {
                    Console.WriteLine(response.Message);
                }
                Console.WriteLine();
                FarmManagerMenu();

            }
            else if (input == 0)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Menu();
            }
            else
            {
                Console.WriteLine("Invalid input kindly select from the options");
                FarmManagerMenu();

            }
        }

        public void RegisterFarmManagerMenu()
        {
            try
            {
                Console.Write("Enter your email address: ");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter your pin: ");
                string pin = Console.ReadLine();
                Console.WriteLine();

                var toSpring = pin.ToString();
                var numbers = "1234567890";
                foreach (var item in toSpring)
                {
                    if (!numbers.Contains(item))
                    {
                        Console.WriteLine("Invalid input. Please use number for your pin");
                        Console.WriteLine();
                        RegisterFarmManagerMenu();
                    }
                }

                Console.Write("Enter your First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter your Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter your Home address: ");
                string address = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter your Phone Number: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your Gender\n press 1 for male\n press 2 for female");
                Gender gender = (Gender)int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Enter your qualification: ");
                string qualification = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your year of Experience");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var response = farmDirectorService.Register(email, int.Parse(pin), firstName, lastName, address, phoneNumber, "Manager", gender, qualification, year);
                if (response.Status == false)
                {
                    Console.WriteLine(response.Message);
                }
                Console.WriteLine("======================= Registered Manager successfully ================");

            }
            catch (Exception)
            {

                Console.WriteLine("Ooopps... create your pin in digits");
                RegisterFarmManagerMenu();

            }



        }
    }
}