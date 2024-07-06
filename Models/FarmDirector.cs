using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.Models
{
    public class FarmDirector : BaseEntity
    {
        public string UserEmail { get; set; } = default!;
        public string Qualification { get; set; } = default!;
        public int YearOfExperience { get; set; }
        public decimal Wallet { get; set; }
       
        public FarmDirector(int id, string userEmail, string qualification, int yearOfExperience, decimal wallet) : base(id)
        {
            UserEmail = userEmail;
            Qualification = qualification;
            YearOfExperience = yearOfExperience;
            Wallet = wallet;
        }

        public override string ToString()
        {
            return $"{Id}\t{UserEmail}\t{Qualification}\t{YearOfExperience}\t{Wallet}";
        }

        public static FarmDirector ConvertToFarmDirectorObj(string st)
        {
            var data = st.Split("\t");
            var farmDirector = new FarmDirector(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]), decimal.Parse(data[4]));
            return farmDirector;
        }


    }
}