using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Interface
{
    public interface IUserService
    {
        UserResponseModel Login(string email, int pin);
        User CurrentUser();
        
    }
}