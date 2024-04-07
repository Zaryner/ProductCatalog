using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Platinum_Star.Models;

namespace Platinum_Star.Models
{
    class ClientModel : INotifyPropertyChanged
    {
        public static List<ClientModel> clients;
        public static ClientModel current;

        string? _name;
        string? _phone;
        string? _address;
        int _id;
        double _discount;

        public ObservableCollection<Content> shoppingProducts;
        public ObservableCollection<ProductModel> likedProducts;

        List<int> _reviews;

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
            shoppingProducts = new ObservableCollection<Content>();
            likedProducts = new ObservableCollection<ProductModel>();
            _reviews = new List<int>();
        }
        public string Name {
            get {
                return _name; 
            }
            set {
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public double Discount { get { return _discount; } set { _discount = value; } }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
