using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Platinum_Star.Models;

namespace Platinum_Star.Models
{
    public class ProductModel
    {
        public static ObservableCollection<ProductModel> products;

        string _name;
        string _description;
        int _id;
        double _price;
        int _count;
        public string _imageUrl;

        List<int> _reviews;
        List<string> _categories;

        static ProductModel()
        {
            products = new ObservableCollection<ProductModel>();
            products.Add(new ProductModel("Воздух 250 мл.", "Тестовый продукт. Он не должен появляться в каталоге", 5.34, 99999999,"product0.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Топорик", "Тестовый продукт. Он не должен появляться в каталоге", 23, 99, "quelling_blade.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Зеленые шарики", "Тестовый продукт. Он не должен появляться в каталоге", 5.34, 3, "tango.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Кларетка", "Увеличивает восстановление маны выбранного существа " +
                "на 6. Действует 25 сек. Восстановление прекращается, если получить урон от вражеского героя или Рошана.", 0.34, 3, "clarity.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Палочка получше", "Мгновенно восстанавливает 15 здоровья и маны за каждый имеющийся заряд. " +
                "Может иметь до 20 зарядов. Получает один заряд каждый раз, когда видимый враг в радиусе 1200 использует способность.", 213, 3, "magic_wand.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Палочка", "Мгновенно восстанавливает 15 здоровья и маны за каждый имеющийся заряд. " +
    "Может иметь до 10 зарядов. Получает один заряд каждый раз, когда видимый враг в радиусе 1200 использует способность.", 213, 3, "magic_stick.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Фейрик", "Чтобы вы были здоровы", 3.50, 3, "faerie_fire.jpg"));
            products[products.Count - 1].AddCateggory("развлечения");
            products.Add(new ProductModel("Блэйд мэйл", "Модная одежда с шипами", 550, 3, "blade_mail.jpg"));
            products[products.Count - 1].AddCateggory("развлечения"); 
            products.Add(new ProductModel("Сабля", "Прям как у мушкетера", 650, 3, "echo_sabre.jpg"));
            products[products.Count - 1].AddCateggory("развлечения"); 
        }

        public ProductModel(string? name, string? description, double price, int count, string imageURL)
        {
            Id = products.Count;
            Name = name;
            Description = description;
            Price = price;
            Count = count;
            _reviews = new List<int>();
            _categories = new List<string>();
            ImageUrl = imageURL;
        }

        ~ProductModel()
        {
            products.Remove(this);
        }

        public string Name 
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
            }
        }
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        public string Description 
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
        public double Rating
        {
            get
            {
                if (_reviews.Count == 0) return -1;
                double rating = 0;
                for (int i = 0; i < _reviews.Count; i++)
                {
                    rating = ReviewModel.reviews[_reviews[i]].Rating;
                }
                return rating;
            }
        }
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }
        public int Count 
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public void AddReview(int review)
        {
            _reviews.Add(review);
        }
        public void RemoveReview(int id)
        {
            _reviews.RemoveAt(id);
        }
        public void ChangeReview(int place, string review)
        {
            ReviewModel.reviews[_reviews[place]].Change(review);
        }
        public void ChangeReview(int place, string review, double rating)
        {
            ReviewModel.reviews[_reviews[place]].Change(review, rating);
        }
        public void AddCateggory(string category)
        {
            _categories.Add(category.ToLower());
        }
        public void RemoveCateggory(string category)
        {
            _categories.Remove(category.ToLower());
        }


        public static explicit operator Content(ProductModel product)
        {
            return new Content(product.Id,1);
        }
    }

}
