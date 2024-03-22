using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum_Star.Models
{
    public class Order
    {
        static List<Order> orders;
        List<Content> content;

        int _clientId;
        int _id;
        string _deliveryStatus;

        static Order()
        {
            orders = new List<Order>();
        }
        public Order(int clientId)
        {
            ClientId = clientId;
            Id = orders.Count;
            orders.Add(this);
            _deliveryStatus = "Создан";
        }
        ~Order()
        {
            orders.Remove(this);
        }

        public void AddContent(Content content)
        {
            this.content.Add(content);
        }
        public int Id { get { return _id; } set { _id = value; } }
        public int ClientId { get { return _clientId; } set { _clientId = value; } }
        public double Price
        {
            get
            {
                double price = 0;
                for (int i = 0; i < content.Count; i++)
                {
                    price += content[i].Price;
                }
                return price;
            }
        }

        public string? DeliveryStatus { get { return _deliveryStatus; } set { _deliveryStatus = value; } }

    }
}
