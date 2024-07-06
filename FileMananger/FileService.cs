using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Models;
using ConsoleAppFishFarminngToFile.Repository;
using ConsoleAppFishFarminngToFile.Repository.Implementation;
using ConsoleAppFishFarminngToFile.Repository.Interface;
using ConsoleAppFishFarminngToFile.Service.Implementation;
using ConsoleAppFishFarminngToFile.Service.Interface;

namespace ConsoleAppFishFarminngToFile.FileMananger
{
    public class FileService : IFileService
    {
        // IUserService userService = new UserService();
        public void CreateFile()
        {
            if (!Directory.Exists("./Files"))
            {
                Directory.CreateDirectory("./Files");
                Console.WriteLine("File Created successfully");
            }

            if (!File.Exists(DataAccess.UserFilePath))
            {
                File.Create(DataAccess.UserFilePath);
            }
            else
            {
                var user = File.ReadAllLines(DataAccess.UserFilePath);
                foreach (var item in user)
                {
                    var userLine = User.ConvertToUserObj(item);
                    DataAccess.users.Add(userLine);
                }
            }

            if (!File.Exists(DataAccess.PondFilePath))
            {
                File.Create(DataAccess.PondFilePath);
            }
            else
            {
                var pond = File.ReadAllLines(DataAccess.PondFilePath);
                foreach (var item in pond)
                {
                    var pondLine = Pond.ConvertToPondObj(item);
                    DataAccess.ponds.Add(pondLine);
                }

            }

            if (!File.Exists(DataAccess.OrderFilePath))
            {
                File.Create(DataAccess.OrderFilePath);
            }

            else
            {
                var order = File.ReadAllLines(DataAccess.OrderFilePath);
                foreach (var item in order)
                {
                    var orderLine = Order.ConvertToOrderObj(item);
                    DataAccess.orderFish.Add(orderLine);
                }

            }

            if (!File.Exists(DataAccess.FarmDirectorFilePath))
            {
                File.Create(DataAccess.FarmDirectorFilePath);
            }
            else
            {
                var farmDir = File.ReadAllLines(DataAccess.FarmDirectorFilePath);
                foreach (var item in farmDir)
                {
                    var farDir = FarmDirector.ConvertToFarmDirectorObj(item);
                    DataAccess.farmDirectors.Add(farDir);
                }
            }

            if (!File.Exists(DataAccess.CustomerFilePath))
            {
                File.Create(DataAccess.CustomerFilePath);
            }
            else
            {
                var customer = File.ReadAllLines(DataAccess.CustomerFilePath);
                foreach (var item in customer)
                {
                    var customerLine = Customer.ConvertToCustomerObj(item);
                    DataAccess.customers.Add(customerLine);
                }

            }

            if (!File.Exists(DataAccess.CategoryFilePath))
            {
                File.Create(DataAccess.CategoryFilePath);
            }
            else
            {

                var category = File.ReadAllLines(DataAccess.CategoryFilePath);
                foreach (var item in category)
                {
                    var categoryLine = Category.ConvertToCategoryObj(item);
                    DataAccess.categories.Add(categoryLine);
                }

            }
            // var getAdmin = userService.Login("admin@gmail.com", 1234);
            // if (getAdmin == null)
            // {
            //     var admin = new User (1, "admin@gmail.com", 1234, "Samuel", "Oyeneye", "Abk", "09023637384", "Admin", Gender.Male);
            //     DataAccess.users.Add(admin);

            // }
            foreach (var farm in DataAccess.ponds)
            {
                Console.WriteLine(farm.SpaceRemain);
            }
            Console.WriteLine("fsxvxffdtyrd");
        }

        
    }
}

