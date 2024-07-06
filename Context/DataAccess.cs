using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Menu;
using ConsoleAppFishFarminngToFile.Models;

namespace ConsoleAppFishFarminngToFile.Context
{
    public class DataAccess
    {
        public static List<User> users= new List<User>()
        {
            new User (1, "admin@gmail.com", 1234,"Samuel", "Oyeneye", "Abeokuta", "08132590745", "Admin", Gender.Male),
            new User(2, "sam@gmail.com", 2233, "sam", "tolu", "abk", "090567", "Manager", Gender.Male)
        };
        

        public static List<Pond> ponds= new List<Pond>();
        public static List<Order> orderFish= new List<Order>();
        public static List<Customer> customers= new List<Customer>();
        public static List<Category> categories= new List<Category>();
        public static List<FarmDirector> farmDirectors = new List<FarmDirector>()
        {
            new FarmDirector(1, "sam@gmail.com", "Bus Admin", 2, 0)
        };

         public static string UserFilePath = "./Files/User.txt";
        public static string PondFilePath = "./Files/Pond.txt";
        public static string OrderFilePath = "./Files/Order.txt";
        public static string FarmDirectorFilePath = "./Files/FarmDirector.txt";
        public static string CustomerFilePath = "./Files/Customer.txt";
        public static string CategoryFilePath = "./Files/Category.txt";


    }
}