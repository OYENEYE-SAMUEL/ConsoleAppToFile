using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Menu;
using ConsoleAppFishFarminngToFile.Models;

namespace ConsoleAppFishFarminngToFile.Repository.Interface
{
    public interface IFarmDirectorRepository
    {
         FarmDirector Register(FarmDirector farmDirector);
        FarmDirector GetManager(string email);
        List <FarmDirector> GetAllDirector();
        FarmDirector Update(FarmDirector farmDirector);
        bool IsDeleted(FarmDirector farmDirector);
        void RefreshFromFile();
       
    }
}