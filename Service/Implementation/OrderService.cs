using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    public class OrderService : IOrderService
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        IOrderRepository orderRepository = new OrderRepository();
        ICustomerRepository customerRepository = new CustomerRepository();
        IFarmDirectorRepository farmDirectorRepository = new FarmDirectorRepository();
        IPondRepository pondRepository = new PondRepository();

        public OrderResponseModel Make(Dictionary<string, int> makeOrder, DateTime dateOrder, string email)
        {
            decimal newTotalPrice = 0;
            foreach (var fish in makeOrder)
            {
                var category = categoryRepository.GetCategoryByName(fish.Key);
                if (category == null)
                {
                    return new OrderResponseModel()
                    {
                        Message = "Category does not exist",
                        Status = false,
                    };
                }

                int quant = fish.Value;
                var price = category.Price * quant;
                var manager = farmDirectorRepository.GetManager(category.ManagerEmail);
                // manager.Wallet += price;
                newTotalPrice += price;
                manager.Wallet += newTotalPrice;
            }
            var getCustomer = customerRepository.GetCustomer(UserService.LoginUser.Email);

            if (getCustomer.Wallet < newTotalPrice)
            {
                // Console.WriteLine("Insufficient balance! kindly fund your wallet");
                return new OrderResponseModel()
                {
                    Message = "Insufficient balance! kindly fund your wallet",
                    Status = false
                };
            }

            foreach (var fish in makeOrder)
            {
                var category = categoryRepository.GetCategoryByName(fish.Key);
                if (category.Quantity == 0 || category.Quantity < fish.Value)
                {
                    return new OrderResponseModel
                    {
                        Message = "there is no available fish",
                        Status = false,
                    };
                }
            }

            foreach (var fish in makeOrder)
            {
                var category = categoryRepository.GetCategoryByName(fish.Key);
                if (category.Quantity == 0 || category.Quantity < fish.Value)
                {
                    // Console.WriteLine($"Oooops! The quantity is not enough to order, remaining: {category.Quantity}");
                    return new OrderResponseModel()
                    {
                        Message = $"The remaining quantity of {fish.Key} is {category.Quantity} which is less than the quantity ordered /{fish.Key}",
                        Status = false,
                    };
                }
                int reduceQuan = fish.Value;
                category.Quantity -= reduceQuan;
            }

            var id = DataAccess.orderFish.Count == 0 ? 1 : DataAccess.orderFish.Count + 1;
            var tagNumber = customerRepository.GetCustomer(email);
            tagNumber.Wallet -= newTotalPrice;
            Order order = new Order(id, tagNumber.TagNumber, dateOrder, makeOrder, newTotalPrice, true);
            orderRepository.Make(order);

            foreach (var item in makeOrder)
            {
                var category = categoryRepository.GetCategoryByName(item.Key);
                var getpond = pondRepository.GetPondbyTagNumber(category.PondTagNumber);
                getpond.SpaceRemain += item.Value;
            }
            
            pondRepository.RefreshFromFile();
            categoryRepository.RefreshFromFile();
            farmDirectorRepository.RefreshFromFile();
            customerRepository.RefreshFromFile();
            return new OrderResponseModel()
            {
                Message = "===========Successfully ordered ============",
                Status = true,
                Order = order,
            };
        }

        // public void CheckAvailable()
        // {
        //     Console.WriteLine("Do you want to fund your wallet?\n yes\n no");
        //     string input = Console.ReadLine();
        //     if (input == "yes")
        //     {
        //         Console.WriteLine("Enter the amount to deposit");
        //         decimal amount = decimal.Parse(Console.ReadLine());
        //         var getCustomer = customerRepository.GetCustomer(UserService.LoginUser.Email);
        //         getCustomer.Wallet += amount;
        //         Console.WriteLine("=========== wallet fund successfully ============");

        //     }
        //     else if (input == "no")
        //     {

        //     }
        //     Console.WriteLine();
        // }
        public OrderResponseModel Delete(string customerTagNumber)
        {
            var order = GetOrder(customerTagNumber);
            if (order == null)
            {
                return new OrderResponseModel()
                {
                    Message = "Order not found",
                    Status = false
                };
            }
            orderRepository.IsDeleted(order.Order);

            return new OrderResponseModel()
            {
                Message = "============ Deleted successful ============",
                Status = true,
                Order = order.Order
            };
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }
        public void ViewAllOrders()
        {
            var getOrder = orderRepository.GetAllOrders();
            foreach (var item in getOrder)
            {
                foreach (var view in item.OrderFish)
                {
                    Console.WriteLine($"Your order: {view.Key} : {view.Value}");
                }
                Console.Write($"Customer TagNo: {item.CustomerTagNumber}\n OrderID: {item.Id}\n Date Order: {item.DateOrder}\n Total price: {item.TotalPrice}\n Order status: {item.IsDelivered}");
            }

        }

        public OrderResponseModel GetOrder(string customerTagNumber)
        {
            var order = orderRepository.GetOrder(customerTagNumber);
            if (order == null)
            {
                return new OrderResponseModel()
                {
                    Message = "Order not found",
                    Status = false
                };
            }
            return new OrderResponseModel()
            {
                Message = "Order is found",
                Status = true,
                Order = order
            };

        }

        public void ViewOrderHistory()
        {
            var getCustomer = customerRepository.GetCustomer(UserService.LoginUser.Email);
            var order = orderRepository.GetOrder(getCustomer.TagNumber);
            foreach (var item in order.OrderFish)
            {
                Console.WriteLine($"Items Order: {item.Key} {item.Value}");
            }
            Console.WriteLine($"Date Order: {order.DateOrder}\n Total Price: {order.TotalPrice}\n Order status: {order.IsDelivered}");


            // foreach (var item in order)
            // {
            //     foreach (var view in item.OrderFish)
            //     {
            //          Console.WriteLine($"Your order: {view.Key} {view.Value}");
            //     }
            //     Console.Write($"Date Order: {item.DateOrder}\n Total price: {item.TotalPrice}\n Order status: {item.IsDelivered}");
            // }

        }




    }
}