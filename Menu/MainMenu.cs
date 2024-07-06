using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminngToFile.Models;
using ConsoleAppFishFarminngToFile.Service;
using ConsoleAppFishFarminngToFile.Service.Implementation;
using ConsoleAppFishFarminngToFile.Service.Interface;

namespace ConsoleAppFishFarminngToFile.Menu
{
    public class MainMenu
    {
        IUserService userService = new UserService();
        
        CustomerBoard customerBoard = new CustomerBoard();
        FarmDirectorBoard farmDirectorBoard = new FarmDirectorBoard();
        AdminBoard adminBoard = new AdminBoard();
        public void Menu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("============== Welcome to Sammy Aquacultures ===================");
                Console.WriteLine("Enter 1 to Register\n Enter 2 to Login\n Enter 3 to Exit");
                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    customerBoard.RegisterCustomerMenu();
                }
                else if (input == 2)
                {
                    LoginMenu();
                }
                else if (input == 3)
                {
                    Console.WriteLine("================== Exit successfully ===================");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input select from the options");
                    Menu();
                }
            }
        }

        public void LoginMenu()

        {

            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter your Pin");
            int pin = int.Parse(Console.ReadLine());
            var userInput = userService.Login(email, pin);
            if (userInput != null)
            {
                if (userInput.User.RoleName == "Admin")
                {
                    adminBoard.AdminMenu();
                }
                else if (userInput.User.RoleName == "Customer")
                {
                    customerBoard.CustomerMenu();
                }
                else if (userInput.User.RoleName == "Manager")
                {
                    farmDirectorBoard.FarmManagerMenu();
                }
                else
                {
                    Console.WriteLine("Invalid role name!");
                }
            }
            else
            {
                Console.WriteLine("Alas!Invalid Input");
            }


        }
    }
}