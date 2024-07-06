using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Interface
{
    public interface IPondService
    {
         PondResponseModel Create(int id, string name, string description, string dimension);
         List<Pond> GetAllPonds();
         PondResponseModel GetPondbyTagNumber(string pondTagNumber);
         PondResponseModel UpdatePond(string pondTagNumber, string name, string description, string dimension);
         void ViewAllPonds();
         PondResponseModel DeletePond(string pondTagNumber);
 
    }
}