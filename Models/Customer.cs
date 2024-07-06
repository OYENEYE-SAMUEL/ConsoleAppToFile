using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppFishFarminng.Models
{
    public class Customer : BaseEntity
    {
        public string UserEmail { get; set; } = default!;
        public string TagNumber { get; set; } = default!;
        public decimal Wallet { get; set; }
        public Customer(int id, string userEmail, string tagNumber, decimal wallet) : base(id)
        {
            UserEmail = userEmail;
            TagNumber = tagNumber;
            Wallet = wallet;
        }

        public override string ToString()
        {
            return $"{Id}\t{UserEmail}\t{TagNumber}\t{Wallet}";
        }

         public static Customer ConvertToCustomerObj(string st)
        {
            var data = st.Split('\t');
            var customer = new Customer(int.Parse(data[0]), data[1], data[2], decimal.Parse(data[3]));
            return customer;
        }


    }
}