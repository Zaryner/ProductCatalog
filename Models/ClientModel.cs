using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platinum_Star.Models;

namespace Platinum_Star.Models
{
    class ClientModel
    {
        public static List<ClientModel> clients;
        public static ClientModel current;

        string? _name;
        string? _phone;
        string? _address;
        int _id;
        double _discount;

        public List<ProductModel> shoppingProducts;
        public List<ProductModel> likedProducts;

        List<int> _reviews;
        List<string> _categories;

        static ClientModel()
        {
            clients = new List<ClientModel>();
            clients.Add(new ClientModel("Гость","","",2));
            current = clients[0];
        }
        public ClientModel(string name, string phone, string address, double discount = 3)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Discount = discount;
            Id = clients.Count;
            clients.Add(this);
            shoppingProducts = new List<ProductModel>();
            likedProducts = new List<ProductModel>();
            _reviews = new List<int>();
            _categories = new List<string>();
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public double Discount { get { return _discount; } set { _discount = value; } }
    }
}
