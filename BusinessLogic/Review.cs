using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platinum_Star.BusinessLogic;

namespace Platinum_Star.BusinessLogic
{
    class Review
    {
        public static List<Review> reviews;
        string? _description;
        int _clientId;
        int _productId;
        int _id;
        double _rating;

        static Review()
        {
            reviews = new List<Review>();
        }

        public Review(int clientId, int productId, string? description, double rating)
        {
            ClientId = clientId;
            ProductId = productId;
            Description = description;
            Rating = rating;
            Id = reviews.Count;
            reviews.Add(this);
        }
        ~Review()
        {
            reviews.Remove(this);
        }

        public string Description { get { return _description; } set { _description = value; } }
        public double Rating { get { return _rating; } set { _rating = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public int ClientId { get { return _clientId; } set { _clientId = value; } }
        public int ProductId { get { return _productId; } set { _productId = value; } }
        public void Change(string description)
        {
            this._description = description;
        }
        public void Change(string description, double rating)
        {
            Description = description;
            Rating = rating;
        }
    }
}
