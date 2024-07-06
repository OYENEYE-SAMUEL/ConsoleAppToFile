using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.Repository.Interface
{
    public interface ICustomerRepository
    {
        Customer Register(Customer customer);
        Customer GetCustomer(string email);
        Customer GetCustomerByTagNumber(string tagNumber);
        List<Customer> GetAllCustomers();
        Customer Update(Customer customer);
        bool IsDeleted(Customer customer);
        void RefreshFromFile();
       
    }
}