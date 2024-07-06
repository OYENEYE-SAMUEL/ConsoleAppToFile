using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.Repository.Interface
{
    public interface IOrderRepository
    {
        Order Make(Order order);
        Order GetOrder(string customerTagNumber);
        List<Order> GetAllOrders();
        Order Update(Order order);
        bool IsDeleted(Order order);
        void RefreshFromFile();

    }
}