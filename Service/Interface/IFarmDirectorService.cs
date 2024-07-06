using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Models;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Interface
{
    public interface IFarmDirectorService
    {
         FarmDirectorResponseModel Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, string roleName, Gender gender, string qualification, int yearOfExperience);
        FarmDirectorResponseModel GetManager(string email);
        List<FarmDirector> GetAllManager();
        FarmDirectorResponseModel Update (string email, string qualification, int yearOfExperience);
        void ViewManagerProfile(string email);
        void ViewAllManagers();
        void ManagerFundWallet(string email, decimal amount);
        void ViewWalletBalance(string email);
        FarmDirectorResponseModel DeleteManager(string email);
    }
}