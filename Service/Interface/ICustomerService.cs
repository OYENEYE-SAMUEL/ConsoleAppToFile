using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Interface
{
    public interface ICustomerService
    {
         CustomerResponseModel Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, Gender gender, decimal wallet);
        CustomerResponseModel GetCustomerByMail(string email);
        CustomerResponseModel GetCustomerByTagNumber(string tagNumber);
        List<Customer> GetAllCustomers();
        CustomerResponseModel CustomerFundWallet(decimal amount, string email);
        void ViewCustomerWallet(string mail);
        public void ViewAllCustomers();
        CustomerResponseModel UpdateProfile(string tagNumber, string email, int id, string newfirst, string newlast, string address, string phone);
        CustomerResponseModel DeleteCustomer(string tagNumber);
    }
}