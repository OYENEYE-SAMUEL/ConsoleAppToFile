using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository.Interface;

namespace ConsoleAppFishFarminngToFile.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
         public Customer Register(Customer customer)
        {
            DataAccess.customers.Add(customer);
             using (var str = new StreamWriter(DataAccess.CustomerFilePath, true))
            {
                string text = customer.ToString();
                str.WriteLine(text);
            }
            return customer;
        }
          
        public List<Customer> GetAllCustomers()
        {
            return DataAccess.customers;
        }

        public Customer GetCustomer(string email)
        {
            foreach (var item in DataAccess.customers)
            {
                if (item.UserEmail == email)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer GetCustomerByTagNumber(string tagNumber)
        {
            foreach (var item in DataAccess.customers)
            {
                if (item.TagNumber == tagNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer Update(Customer customer)
        {
            var getCustomer = GetCustomer(customer.UserEmail);
            if (getCustomer == null)
            {
                return null;
            }
            getCustomer.Wallet  = customer.Wallet;
            getCustomer.UserEmail = customer.UserEmail;
            getCustomer.TagNumber = customer.TagNumber;
            RefreshFromFile();
            return getCustomer;
        }

        public bool IsDeleted(Customer customer)
        {
            DataAccess.customers.Remove(customer);
            RefreshFromFile();
            return true;
        }

       

        public void RefreshFromFile()
        {
              File.WriteAllText(DataAccess.CustomerFilePath, string.Empty);
            foreach (var item in DataAccess.customers)
            {
                using (var str = new StreamWriter(DataAccess.CustomerFilePath, true))
                {
                str.WriteLine(item.ToString());
                }
            }
        }
    }
}