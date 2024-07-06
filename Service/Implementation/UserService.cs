using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Repository.Implementation;
using ConsoleAppFishFarminngToFile.Repository.Interface;
using ConsoleAppFishFarminngToFile.Service.Interface;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Implementation
{
    public class UserService : IUserService
    {
        IUserRepository userRepository = new UserRepository();

       
        public static User LoginUser;

          public User CurrentUser()
        {
            return LoginUser;
        }
        public UserResponseModel Login(string email, int pin)
        {
            var response = userRepository.GetUserByEmail(email);
            if (response == null)
            {
                return new UserResponseModel()
                {
                    Message = "User not found",
                    Status = false
                };
            }

            if (response.Pin != pin)
            {
                return new UserResponseModel()
                {
                    Message = "Invalid Password",
                    Status = false
                };
            }
           LoginUser = response;
           return new UserResponseModel()
           {
                Message = "Login Sucessful",
                Status = true,
                User = response
           };
        }

       
    }
}