using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum_Star.Models
{
    public class Content
    {
        int _productId;
        int _count;

        public Content(int productId, int count)
        {
            ProductId = productId;
            Count = count;
        }

        public int ProductId { get { return _productId; } set { _productId = value; } }
        public int Count { get { return _count; } set { _count = value; } }
        public double Price { get { return Count * ProductModel.products[ProductId].Price; } }

    }
}
