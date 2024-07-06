using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Interface
{
    public interface IOrderService
    {
        OrderResponseModel Make(Dictionary<string, int> makeOrder, DateTime dateOrder, string email);
        OrderResponseModel GetOrder(string customerTagNumber);
        List<Order> GetAllOrders();
         void ViewOrderHistory();
         void ViewAllOrders();
        OrderResponseModel Delete(string customerTagNumber);

    }
}