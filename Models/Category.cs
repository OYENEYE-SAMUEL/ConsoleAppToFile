using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppFishFarminng.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Period { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PondTagNumber { get; set; }
        public string ManagerEmail { get; set; }

          public Category(int id, string name, string period, decimal price, int quantity, string pondTagNumber, string managerEmail) : base(id)
        {
            Name = name;
            Period = period;
            Price = price;
            Quantity = quantity;
            PondTagNumber = pondTagNumber;
            ManagerEmail = managerEmail;
        }

        public  override string ToString()
        {
            return $"{Id}\t{Name}\t{Period}\t{Price}\t{Quantity}\t{PondTagNumber}\t{ManagerEmail}";
        }

         public static Category ConvertToCategoryObj(string st)
        {
            var data = st.Split('\t');
            var category = new Category(int.Parse(data[0]), data[1], data[2], decimal.Parse(data[3]), int.Parse(data[4]), data[5], data[6]);
            return category;
        }
    }
}