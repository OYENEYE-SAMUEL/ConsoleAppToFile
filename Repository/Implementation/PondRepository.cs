using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository.Interface;

namespace ConsoleAppFishFarminngToFile.Repository
{
    public class PondRepository : IPondRepository
    {
        public Pond Create(Pond pond)
        {
            DataAccess.ponds.Add(pond);
            using (var str = new StreamWriter(DataAccess.PondFilePath, true))
            {
                string text = pond.ToString();
                str.WriteLine(text);
            }
            return pond;
        }

        public List<Pond> GetAllPonds()
        {
            return DataAccess.ponds;
        }

        public Pond GetPondbyTagNumber(string pondTagNumber)
        {
            foreach (var item in DataAccess.ponds)
            {
                if (item.PondTagNumber == pondTagNumber)
                {
                    return item;
                }
            }
            return null;
        }
        public Pond GetPondByName(string pondName)
        {
            foreach (var item in DataAccess.ponds)
            {
                if (item.Name == pondName)
                {
                    return item;
                }
            }
            return null;
        }

        public bool IsDeleted(Pond pond)
        {
            DataAccess.ponds.Remove(pond);
            RefreshFromFile();
            return true;
        }



        public void RefreshFromFile()
        {
            File.WriteAllText(DataAccess.PondFilePath, string.Empty);
            foreach (var item in DataAccess.ponds)
            {
                using (var str = new StreamWriter(DataAccess.PondFilePath, true))
                {
                    str.WriteLine(item.ToString());
                }
            }
        }

        public Pond Update(Pond pond)
        {
            var Getpond = GetPondbyTagNumber(pond.PondTagNumber);
            if (Getpond == null)
            {
                return null;
            }
            Getpond.PondSize = pond.PondSize;
            Getpond.Name = pond.Name;
            Getpond.Description = pond.Description;
            RefreshFromFile();
            return pond;
        }
    }
}