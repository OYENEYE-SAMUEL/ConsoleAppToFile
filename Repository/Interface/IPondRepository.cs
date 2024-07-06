using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.Repository.Interface
{
    public interface IPondRepository
    {
        Pond Create(Pond pond);
         List<Pond> GetAllPonds();
         Pond GetPondbyTagNumber(string pondTagNumber);
         public Pond GetPondByName(string pondName);
         Pond Update(Pond pond);
         bool IsDeleted(Pond pond);
        void RefreshFromFile();
       
    }
}