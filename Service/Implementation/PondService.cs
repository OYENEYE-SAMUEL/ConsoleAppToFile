using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository;
using ConsoleAppFishFarminngToFile.Repository.Implementation;
using ConsoleAppFishFarminngToFile.Repository.Interface;
using ConsoleAppFishFarminngToFile.Service.Implementation;
using ConsoleAppFishFarminngToFile.Service.Interface;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service
{
    public class PondService : IPondService
    {
       IPondRepository pondRepository = new PondRepository();
        
        public PondResponseModel Create(int id, string name, string description, string dimension)
        {
            string pondTagNum = GeneratePondTagNum(id);
            var existPond = pondRepository.GetPondbyTagNumber(pondTagNum);
            if (existPond != null)
            {
                return new PondResponseModel()
                {
                    Message = "Pond already exist",
                    Status = false
                };
            }
           var dimensions = dimension.Split('x');
           dimensions[0] = dimensions[0].Trim();
           dimensions[1] = dimensions[1].Trim();
           int measure = int.Parse(dimensions[0]);
           int measureDim = int.Parse(dimensions[1]);
           var totalDim = measure * measureDim * 1000;
             id = DataAccess.ponds.Count == 0 ? 1 : DataAccess.ponds.Count + 1;
            Pond pond = new Pond(id, name, description, pondTagNum, dimension, totalDim, UserService.LoginUser.Email);
            pondRepository.Create(pond);
            return new PondResponseModel()
            {
                Message = "======== Pond Created Successfully ================",
                Status = true,
                Pond = pond
            };
        }

         private string GeneratePondTagNum(int id)
        {
            Random rand = new Random();
            return $"{rand.Next(20, 1000)}/{id}";
        }

        public List<Pond> GetAllPonds()
        {
            var ponds =  pondRepository.GetAllPonds();
            foreach(var item in ponds)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Description}\t{item.PondSize}\t{item.Dimension}\t{item.SpaceRemain}");
            }
            return ponds;
        }

        public void ViewAllPonds()
        {
            var getPond = pondRepository.GetAllPonds();
            foreach (var item in getPond)
            {
                Console.WriteLine($"Pond Id: {item.Id}\n Pond Name: {item.Name}\n Pond Size: {item.PondSize}\n Pond Describe: {item.Description}\n Pond TagNo: {item.PondTagNumber}\n Size: {item.PondSize}\n Dimension: {item.Dimension}");
            }
        }

        public PondResponseModel GetPondbyTagNumber(string pondTagNumber)
        {
            var pond = pondRepository.GetPondbyTagNumber(pondTagNumber);
            if (pond == null)
            {
                return new PondResponseModel()
                {
                    Message = "Pond not found",
                    Status = false
                };
            }
            return new PondResponseModel()
            {
                Message = "pond is found",
                Status = true,
                Pond = pond
            };
        }

        public PondResponseModel UpdatePond(string pondTagNumber,string name, string description, string dimension)
        {
            var pond = pondRepository.GetPondbyTagNumber(pondTagNumber);
            if (pond == null)
            {
                return new PondResponseModel()
                {
                    Message = "pond not found",
                    Status = false
                };
            }
            
            pond.Name = name;
            pond.Description = description;
            
            return new PondResponseModel()
            {
                Message = "============== Pond updated successfully ==============",
                Status = true,
                Pond = pond
            };
        }

         public PondResponseModel DeletePond(string pondTagNumber)
        {
            var pond = pondRepository.GetPondbyTagNumber(pondTagNumber);
            if (pond != null)
            {
                 Console.WriteLine("The pond does not exist");
                return new PondResponseModel()
                {
                    Message = "********* The pond does not exist ****************",
                    Status = false,
                };
            }
            pondRepository.IsDeleted(pond);
            return new PondResponseModel()
            {
                Message = " ============= Deleted successfully ===========",
                Status = true,
                Pond = pond
            };
        }
    }
}