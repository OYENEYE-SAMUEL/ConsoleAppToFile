using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Models;
using ConsoleAppFishFarminngToFile.Repository.Implementation;
using ConsoleAppFishFarminngToFile.Repository.Interface;
using ConsoleAppFishFarminngToFile.Service.Interface;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service
{
    public class FarmDirectorService : IFarmDirectorService
    {
        IFarmDirectorRepository farmDirectorRepository = new FarmDirectorRepository();
        IUserRepository userRepository = new UserRepository();
        public FarmDirectorResponseModel Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, string roleName, Gender gender, string qualification, int yearOfExperience)
        {
            var exist = farmDirectorRepository.GetManager(email);
            if (exist != null)
            {
                return new FarmDirectorResponseModel()
                {
                    Message = "Manager already exist",
                    Status = false
                };
            }

            var id = DataAccess.users.Count == 0 ? 1 : DataAccess.users.Count + 1;
            var user = new User(id, email, pin, firstName, lastName, address, phoneNumber, "Manager", gender);
            userRepository.Create(user);

            id = DataAccess.farmDirectors.Count == 0 ? 1 : DataAccess.farmDirectors.Count + 1;
            FarmDirector farmDirector = new FarmDirector(id, email, qualification, yearOfExperience, 0);
            farmDirectorRepository.Register(farmDirector);
            return new FarmDirectorResponseModel()
            {
                Message = "Create successfully",
                Status = true,
                FarmDirector = farmDirector
            };
        }

        public FarmDirectorResponseModel DeleteManager(string email)
        {
            var manager = farmDirectorRepository.GetManager(email);
            if (manager == null)
            {
                return new FarmDirectorResponseModel()
                {
                    Message = "Manager not found",
                    Status = false,
                };
            }
            farmDirectorRepository.IsDeleted(manager);
            return new FarmDirectorResponseModel()
            {
                Message = "Deleted successfully",
                Status = true,
                FarmDirector = manager
            };
        }

        public List<FarmDirector> GetAllManager()
        {
            return farmDirectorRepository.GetAllDirector();
        }

        public void ViewAllManagers()
        {
            var manager = farmDirectorRepository.GetAllDirector();
            foreach (var item in manager)
            {
                Console.WriteLine($"Id: {item.Id}\n Email: {item.UserEmail}\n YOE: {item.YearOfExperience}\n Qualification: {item.Qualification}");
            }
        }

        public FarmDirectorResponseModel GetManager(string email)
        {
            var manager = farmDirectorRepository.GetManager(email);
            if (manager == null)
            {
                return new FarmDirectorResponseModel()
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            return new FarmDirectorResponseModel()
            {
                Message = "Manager is found",
                Status = true,
                FarmDirector = manager
            };
        }

        public void ManagerFundWallet(string email, decimal amount)
        {
            var manager = farmDirectorRepository.GetManager(email);
            manager.Wallet += amount;

        }

        public void ViewWalletBalance(string email)
        {
            var getMan = farmDirectorRepository.GetManager(email);
            Console.WriteLine($"Wallet Balance: {getMan.Wallet}");
        }



        public FarmDirectorResponseModel Update(string email, string qualification, int yearOfExperience)
        {
            var manager = farmDirectorRepository.GetManager(email);
            if (manager == null)
            {
                return new FarmDirectorResponseModel()
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            manager.Qualification = qualification;
            manager.YearOfExperience = yearOfExperience;
            return new FarmDirectorResponseModel()
            {
                Message = "Updated successfully",
                Status = true,
                FarmDirector = manager
            };
        }

        public void ViewManagerProfile(string email)
        {
            var manager = GetManager(email);
            var getMan = userRepository.GetUserByEmail(email);
            Console.WriteLine($"ID: {getMan.Id}\n NAME: {getMan.FirstName} {getMan.LastName}\n GENDER: {getMan.Gender}\n PHONE: {getMan.PhoneNumber}\n ADDRESS: {getMan.Address}\n EMAIL: {getMan.Email}\n Y.O.E: {manager.FarmDirector.YearOfExperience}\n QUALIFICATION: {manager.FarmDirector.Qualification}");
        }



    }
}