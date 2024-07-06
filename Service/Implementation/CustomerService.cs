using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository;
using ConsoleAppFishFarminngToFile.Repository.Implementation;
using ConsoleAppFishFarminngToFile.Repository.Interface;
using ConsoleAppFishFarminngToFile.Service.Implementation;
using ConsoleAppFishFarminngToFile.Service.Interface;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        IUserRepository userRepository = new UserRepository();
        public CustomerResponseModel Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, Gender gender, decimal wallet)
        {
           var exist = customerRepository.GetCustomer(email);
           if (exist != null)
           {
                return new CustomerResponseModel()
                {
                    Message = "Customer already exist",
                    Status = false
                };
           }
           
           var id = DataAccess.users.Count == 0? 1 : DataAccess.users.Count + 1;
           var user = new User(id, email, pin, firstName, lastName, address, phoneNumber, "Customer", gender);
           userRepository.Create(user);

            id = DataAccess.customers.Count == 0 ? 1 : DataAccess.customers.Count + 1;
           var customerTagNo= GenerateCustomerTagNumber(firstName, lastName);
           var customer = new Customer(id, email, customerTagNo, 0);
           customerRepository.Register(customer);
           return new CustomerResponseModel()
           {
                Message = "==========Created successfullly============",
                Status = true,
                Customer = customer
           };
           
        }

        private string GenerateCustomerTagNumber(string firstName, string lastName)
        {
            Random rand = new Random();

            return $"FM/{Upper(firstName[0])}/{Upper(lastName[0])}/{rand.Next(500, 700000)}";

        }

         private string Upper(char a)
        {
            return a.ToString().ToUpper();
        }

        public CustomerResponseModel CustomerFundWallet(decimal amount, string email)
        {
            var customer = customerRepository.GetCustomer(email);
            customer.Wallet += amount;
            Console.WriteLine($"");
            return new CustomerResponseModel()
            {
                Message = "***************** Wallet fund succesfully ****************",
                Status = true,
                Customer = customer
            };
        }
        public CustomerResponseModel DeleteCustomer(string tagNumber)
        {
            var customer = customerRepository.GetCustomerByTagNumber(tagNumber);
            if(customer == null)
            {
                return new CustomerResponseModel()
                {
                    Message = "customer not found",
                    Status = false,
                };
            }
           customerRepository.IsDeleted(customer);
        //    Console.WriteLine("================ Deleted successfully ===============");
           return new CustomerResponseModel()
           {
                Message = "Deleted successfully",
                Status = true,
                Customer = customer
           };
            
            
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
                
        }

        public void ViewAllCustomers()
        {
            var customers = customerRepository.GetAllCustomers();
            foreach (var item in customers)
            {
                Console.WriteLine($"Id: {item.Id}\n Email: {item.UserEmail}\n TagNo: {item.TagNumber}");
            }
        }

        public CustomerResponseModel GetCustomerByMail(string email)
        {
            var customer = customerRepository.GetCustomer(email);
            if(customer == null)
            {
                return new CustomerResponseModel()
                {
                    Message = "Customer not found",
                    Status = false,
                    Customer = customer
                };
            }
            return new CustomerResponseModel()
            {
                Message = "Customer is found",
                Status = true,
                Customer = customer
            };
        }

        public CustomerResponseModel GetCustomerByTagNumber(string tagNumber)
        {
            var customer = customerRepository.GetCustomerByTagNumber(tagNumber);
            if (customer == null)
            {
               return new CustomerResponseModel()
                {
                    Message = "Customer not found",
                    Status = false,
                    Customer = customer
                };
            }
             return new CustomerResponseModel()
            {
                Message = "Customer is found",
                Status = true,
                Customer = customer
            };
        }

        public void ViewProfile(string mail)
        {
            var GetCustomerByMail = customerRepository.GetCustomer(mail);
              var getCusto = userRepository.GetUserByEmail(GetCustomerByMail.UserEmail);
              var view = customerRepository.GetCustomer(GetCustomerByMail.UserEmail);
              Console.WriteLine($"ID: {getCusto.Id}\n NAME: {getCusto.FirstName} {getCusto.LastName}\n EMAIL:{getCusto.Email}\n ADDRESS: {getCusto.Address}\n GENDER: {getCusto.Gender}\n PHONE NO: {getCusto.PhoneNumber}\n TAG NO: {view.TagNumber}");
        }

        public void ViewCustomerWallet(string mail)
        {
            var view = customerRepository.GetCustomer(mail);
            Console.WriteLine($"Wallet Balance: {view.Wallet}");
        }


        public CustomerResponseModel UpdateProfile(string tagNumber, string email, int id, string newfirst, string newlast, string address, string phone)
        {
            var customer = GetCustomerByTagNumber(tagNumber);
            var getCusto = userRepository.GetUser(id);
            
            if (customer == null)
            {
                 return new CustomerResponseModel()
                {
                    Message = "Customer not found",
                    Status = false,
                };
            }
            getCusto.FirstName = newfirst;
            getCusto.LastName = newlast;
            getCusto.PhoneNumber = phone;
            getCusto.Address = address;
            getCusto.Email = email;
             return new CustomerResponseModel()
            {
                Message = "Customer is found",
                Status = true,
                Customer = customer.Customer
            };
            
        }

       

    }
}