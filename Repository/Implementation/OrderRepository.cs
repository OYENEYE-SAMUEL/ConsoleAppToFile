using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository.Interface;

namespace ConsoleAppFishFarminngToFile.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order Make(Order order)
        {
            DataAccess.orderFish.Add(order);
            using (var str = new StreamWriter(DataAccess.OrderFilePath, true))
            {
                string text = order.ToString();
                str.WriteLine(text);
            }
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return DataAccess.orderFish;
        }

        public Order GetOrder(string customerTagNumber)
        {
            foreach (var item in DataAccess.orderFish)
            {
                if (item.CustomerTagNumber == customerTagNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public Order Update(Order order)
        {
            var getOrder = GetOrder(order.CustomerTagNumber);
            if (getOrder == null)
            {
                return null;
            }
            getOrder.OrderFish = order.OrderFish;
            getOrder.DateOrder = order.DateOrder;
            getOrder.CustomerTagNumber = order.CustomerTagNumber;
            getOrder.TotalPrice = order.TotalPrice;
            getOrder.IsDelivered = order.IsDelivered;
            RefreshFromFile();
            return order;
        }

        public bool IsDeleted(Order order)
        {
            DataAccess.orderFish.Remove(order);
            RefreshFromFile();
            return true;
        }



        public void RefreshFromFile()
        {
            File.WriteAllText(DataAccess.OrderFilePath, string.Empty);
            foreach (var item in DataAccess.orderFish)
            {
                using (var str = new StreamWriter(DataAccess.OrderFilePath, true))
                {
                    str.WriteLine(item.ToString());
                }
            }
        }
    }
}