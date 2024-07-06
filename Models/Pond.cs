using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppFishFarminng.Models
{
    public class Pond : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string ManagerEmail { get; set; }
        public string? Description { get; set; }
        public string PondTagNumber { get; set; } = default!;
        public int PondSize { get; set; } = default!;
        public string Dimension { get; set; } = default!;
        public int SpaceRemain { get; set; }

        public Pond(int id, string managerEmail, string name, string description, string pondTagNumber, int pondSize, string dimension) : base(id)
        {
            Name = name;
             ManagerEmail = managerEmail;
            Description = description;
            PondTagNumber = pondTagNumber;
            PondSize = pondSize;
            Dimension = dimension;
            SpaceRemain = PondSize;
           
        }
        public Pond(int id) : base(id)
        {
            
        }

        public override string ToString()
        {
            return $"{Id}\t{ManagerEmail}\t{Name}\t{Description}\t{PondTagNumber}\t{PondSize}\t{Dimension}\t{SpaceRemain}";
        }

         public static Pond ConvertToPondObj(string st)
        {
            var data = st.Split('\t');
            var pond = new Pond(int.Parse(data[0]))
            {
                Name = data[1],
                ManagerEmail = data[2],
                Description = data[3],
                PondTagNumber = data[4],
                PondSize = int.Parse(data[5]),
                Dimension = data[6],
                SpaceRemain = int.Parse(data[7])
            };
            return pond;
        }



    }
}