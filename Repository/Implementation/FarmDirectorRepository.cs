using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Menu;
using ConsoleAppFishFarminngToFile.Models;
using ConsoleAppFishFarminngToFile.Repository.Interface;

namespace ConsoleAppFishFarminngToFile.Repository.Implementation
{
    public class FarmDirectorRepository : IFarmDirectorRepository
    {
        public FarmDirector Register(FarmDirector farmDirector)
        {
            DataAccess.farmDirectors.Add(farmDirector);
            using (var str = new StreamWriter(DataAccess.FarmDirectorFilePath, true))
            {
                string text = farmDirector.ToString();
                str.WriteLine(text);
            }
            return farmDirector;
        }

        public List<FarmDirector> GetAllDirector()
        {
            return DataAccess.farmDirectors;
        }

        public FarmDirector GetManager(string email)
        {
            foreach (var item in DataAccess.farmDirectors)
            {
                if (item.UserEmail == email)
                {
                    return item;
                }
            }
            return null;
        }

        public FarmDirector Update(FarmDirector farmDirector)
        {
            var fardir = GetManager(farmDirector.UserEmail);
            if (fardir == null)
            {
                return null;
            }
            fardir.UserEmail = farmDirector.UserEmail;
            fardir.Wallet = farmDirector.Wallet;
            fardir.YearOfExperience = farmDirector.YearOfExperience;
            fardir.Qualification = farmDirector.Qualification;
            RefreshFromFile();
            return fardir;
        }

        public bool IsDeleted(FarmDirector farmDirector)
        {
            DataAccess.farmDirectors.Remove(farmDirector);
            RefreshFromFile();
            return true;
        }

       
        public void RefreshFromFile()
        {
                File.WriteAllText(DataAccess.FarmDirectorFilePath, string.Empty);
                foreach (var item in DataAccess.farmDirectors)
                {
                    using (var str = new StreamWriter(DataAccess.FarmDirectorFilePath, true))
                    {
                        str.WriteLine(item.ToString());
                    }
                }
        }

       
    }
}