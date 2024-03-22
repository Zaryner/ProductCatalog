using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platinum_Star.Models;

namespace Platinum_Star
{
    class ProductSearchHandler:SearchHandler
    {
        public IList<ProductModel> Products { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }
        

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Products
                    .Where(product => (product.Name.ToLower().Contains(newValue.ToLower())||
                    product.Name.ToLower().Contains(ToRussianLayaut(newValue.ToLower()))))
                    .ToList<ProductModel>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);


            this.IsSearchEnabled = false;
            this.IsSearchEnabled = true;
        

        ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            // The following route works because route names are unique in this app.
            await Shell.Current.GoToAsync($"productpage?id={((ProductModel)item).Id}");
        }

        public static string ToRussianLayaut(string s)
        {
            // Создать таблицу соответствия символов английской и русской раскладок
            Dictionary<char, char> charMap = new Dictionary<char, char>()
    {
        { 'a', 'ф' }, { 'b', 'и' }, { 'c', 'с' }, { 'd', 'в' }, { 'e', 'у' },
        { 'f', 'а' }, { 'g', 'п' }, { 'h', 'р' }, { 'i', 'ш' }, { 'j', 'о' },
        { 'k', 'л' }, { 'l', 'д' }, { 'm', 'ь' }, { 'n', 'т' }, { 'o', 'щ' },
        { 'p', 'з' }, { 'q', 'й' }, { 'r', 'к' }, { 's', 'ы' }, { 't', 'е' },
        { 'u', 'г' }, { 'v', 'м' }, { 'w', 'ц' }, { 'x', 'ч' }, { 'y', 'н' },
        { 'z', 'я' }, { 'A', 'Ф' }, { 'B', 'И' }, { 'C', 'С' }, { 'D', 'В' }, { 'E', 'У' },
        { 'F', 'А' }, { 'G', 'П' }, { 'H', 'Р' }, { 'I', 'Ш' }, { 'J', 'О' },
        { 'K', 'Л' }, { 'L', 'Д' }, { 'M', 'Ь' }, { 'N', 'Т' }, { 'O', 'Щ' },
        { 'P', 'З' }, { 'Q', 'Й' }, { 'R', 'К' }, { 'S', 'Ы' }, { 'T', 'Е' },
        { 'U', 'Г' }, { 'V', 'М' }, { 'W', 'Ц' }, { 'X', 'Ч' }, { 'Y', 'Н' },
        { 'Z', 'Я' }
    };

            // Перевести строку
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (charMap.ContainsKey(c))
                {
                    sb.Append(charMap[c]);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
      
    }
}
