using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Service;
using ConsoleAppFishFarminngToFile.Service.Implementation;
using ConsoleAppFishFarminngToFile.Service.Interface;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Menu
{
    public class CustomerBoard
    {
        ICustomerService _customerService = new CustomerService();
        CustomerService customerService = new CustomerService();
        // IUserService userService= new UserService();
        ICategoryService categoryService = new CategoryService();
        IOrderService orderService = new OrderService();

        public void CustomerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("============== Welcome to Customer DashBoard =====================");
            Console.WriteLine("1: View Profile\n 2: View wallet balance");
            Console.WriteLine("3: Fund Wallet");
            Console.WriteLine("4: View all category of fish");
            Console.WriteLine("5: Make order");
            Console.WriteLine(" 6: View order history");
            Console.WriteLine("7: Delete account ");
            Console.WriteLine("99: To Menu");
            Console.WriteLine("0: to Logout");

            Console.WriteLine("==================\n ==========");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                customerService.ViewProfile(UserService.LoginUser.Email);
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 2)
            {

                customerService.ViewCustomerWallet(UserService.LoginUser.Email);
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 3)
            {
                Console.WriteLine("Input the amount to add to wallet: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                customerService.CustomerFundWallet(amount, UserService.LoginUser.Email);
                Console.WriteLine(customerService.CustomerFundWallet(amount, UserService.LoginUser.Email).Message);
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 4)
            {

                categoryService.ViewAllCategory();
                Console.WriteLine();
                CustomerMenu();
            }
            else if (input == 5)
            {
                Console.WriteLine("How many items to be ordered?");
                int custInput = int.Parse(Console.ReadLine());
                var orders = new Dictionary<string, int>();
                for (int i = 0; i < custInput; i++)
                {
                    Console.WriteLine("Enter the type of fish to be ordered: ");
                    string fishType = Console.ReadLine();
                    if (orders.ContainsKey(fishType))
                    {
                        Console.WriteLine("Items has already been ordered");
                        Console.WriteLine("Do you want to increase the quantity ordered? (Y/N)");
                        char increase = char.Parse(Console.ReadLine().ToUpper());
                        if (increase == 'Y')
                        {
                            Console.WriteLine($"The remaining quantity ordered before {orders[fishType]}");
                            Console.WriteLine("Enter new quantity: ");
                            int quan = int.Parse(Console.ReadLine());
                            orders[fishType] = quan;
                        }
                        continue;

                    }

                    Console.WriteLine("How many do you want: ");
                    int number = int.Parse(Console.ReadLine());
                    orders.Add(fishType, number);
                }

            Start:
                var makeOrder = orderService.Make(orders, DateTime.Now, UserService.LoginUser.Email);
                if (makeOrder.Status == true)
                {
                    Console.WriteLine(makeOrder.Message);
                }
                else
                {
                    if (makeOrder.Message == "Insufficient balance! kindly fund your wallet")
                    {
                        Console.WriteLine(makeOrder.Message);
                        Console.WriteLine("Do you want to fund your wallet? (Y/N)");
                        char request = char.Parse(Console.ReadLine().ToUpper());
                        if (request == 'Y')
                        {
                            Console.WriteLine("Enter the amount to deposit");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            customerService.CustomerFundWallet(amount, UserService.LoginUser.Email);
                            goto Start;
                        }
                        else
                        {
                            CustomerMenu();
                        }

                    }
                    else if (makeOrder.Message.Contains("which is less than the quantity ordered"))
                    {
                        Console.WriteLine(makeOrder.Message.Split('/')[0]);
                        Console.Write("Do you want to order this item?  (Y/N)");
                        char ans = char.Parse(Console.ReadLine().ToUpper());
                        if (ans == 'Y')
                        {
                            Console.Write("Enter the quantity you want to order: ");
                            int quanOrder = int.Parse(Console.ReadLine());
                            orders[makeOrder.Message.Split('/')[1]] = quanOrder;
                            goto Start;
                        }
                    }
                    else
                    {
                        Console.WriteLine("An error occur while ordering, kindly try again");
                    }
                }

                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 6)
            {
                orderService.ViewOrderHistory();
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 7)
            {
                Console.WriteLine("Enter your tag number to delete your account: ");
                string tagNumber = Console.ReadLine();
                orderService.Delete(tagNumber);
                Console.WriteLine();
                Console.WriteLine(orderService.Delete(tagNumber).Message);
                MainMenu mainMenu = new MainMenu();
                mainMenu.Menu();
            }
            else if (input == 99)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Menu();
            }
            else if (input == 0)
            {
                Console.WriteLine("*********** Logout successfully ************");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Invalid input, kindly select from the options");
                CustomerMenu();
            }
        }
        public void RegisterCustomerMenu()
        {
            try
            {
                Console.WriteLine("============= Welcome to Customer Registration, kindly make use of valid info ==============");
                Console.WriteLine("Enter your email address: ");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Kindly make use of number.....Create your new pin: ");
                string pin = Console.ReadLine();

                var toSpring = pin.ToString();
                var numbers = "1234567890";
                foreach (var item in toSpring)
                {
                    if (!numbers.Contains(item))
                    {
                        Console.WriteLine("Invalid input. Please use number for your pin");
                        Console.WriteLine();
                        RegisterCustomerMenu();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Enter your First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your address: ");
                string address = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your phone Number: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your Gender\n press 1 for male\n press 2 for female");
                Gender gender = (Gender)int.Parse(Console.ReadLine());
                Console.WriteLine();
                var customer = _customerService.Register(email, int.Parse(pin), firstName, lastName, address, phoneNumber, gender, 0);
                if (customer.Message == "==========Created successfullly============")
                {
                    Console.WriteLine(customer.Message);
                    Console.WriteLine();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Ooopps... Invalid access");
                RegisterCustomerMenu();

            }

        }
    }
}