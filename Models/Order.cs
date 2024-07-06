using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFishFarminng.Models
{
    public class Order : BaseEntity
    {
        public string CustomerTagNumber { get; set; } = default!;
        public DateTime DateOrder { get; set; } = DateTime.Now;
        public bool IsDelivered { get; set; }
        public Dictionary<string, int> OrderFish { get; set; } = new Dictionary<string, int>();
        public decimal TotalPrice { get; set; }

        public Order(int id, string customerTagNumber, DateTime dateOrder, Dictionary<string, int> orderFish, decimal totalPrice, bool isDelivered) : base(id)
        {

            CustomerTagNumber = customerTagNumber;
            DateOrder = dateOrder;
            OrderFish = orderFish;
            TotalPrice = totalPrice;
            IsDelivered = isDelivered;
        }

        public override string ToString()
        {
            StringBuilder disOrder = new StringBuilder();
            {
                foreach (var item in OrderFish)
                {
                    disOrder.Append($"{item.Key} : {item.Value}");
                }
            }
            return $"{Id}\t{CustomerTagNumber}\t{DateOrder}\t{disOrder}\t{TotalPrice}\t{IsDelivered}";
        }

        public static Order ConvertToOrderObj(string st)
        {
            var data = st.Split('\t');
            var dictionaryData = data[3];
            var dicOrder = new Dictionary<string, int>();
            //var dicOrder2 = JsonSerializer.Deserialize<Dictionary<string, int>>(dictionaryData);
            string[] pairs = dictionaryData.Split(':');
            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split(':');
                if (keyValue.Length == 2 && int.TryParse(keyValue[1], out int value))
                {
                    dicOrder[keyValue[0]] = value;
                }
            }
            var order = new Order(int.Parse(data[0]), data[1], DateTime.Parse(data[2]), dicOrder, decimal.Parse(data[4]), bool.Parse(data[5]));
            return order;
        }


    }
}