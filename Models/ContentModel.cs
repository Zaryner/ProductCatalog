using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Platinum_Star.Models
{
    public class Content : INotifyPropertyChanged
    {
        int _productId;
        int _count;
        ProductModel _product;

        public Content(int productId, int count)
        {
            ProductId = productId;
            Count = count;
        }
        
        public ProductModel Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }

        public int ProductId 
        { 
            get {
                return _productId;
            } set {
                _productId = value;
                Product = ProductModel.products[ProductId];
                OnPropertyChanged("ProductId");
            } 

        }
        public int Count {
            get {
                return _count;
            }
            set { 
                _count = value;
                OnPropertyChanged("Count");
            } 
        }
        public double Price {
            get
            { 
                return Count * ProductModel.products[ProductId].Price; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public override bool Equals(object obj)
        {
            if(obj is Content content)
            {
                return ProductId == content.ProductId;
            }
            return base.Equals(obj);
        }
    }
}
