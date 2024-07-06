using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.Repository.Interface
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetUser(int id);
        User GetUserByEmail(string email);
        List<User> GetAllUser();
        void RefreshFromFile();

    }
}