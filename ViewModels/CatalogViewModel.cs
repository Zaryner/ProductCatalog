using Platinum_Star.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Platinum_Star.ViewModels
{
    internal class CatalogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProductModel> Products { get; set; }
        public ObservableCollection<Button> LikeButtons { get; set; }
        public ObservableCollection<Button> ToCartButtons { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand LikeCommand { get; set; }

        public CatalogViewModel()
        {
            LikeButtons = new ObservableCollection<Button>();
            ToCartButtons = new ObservableCollection<Button>();
            Products = new ObservableCollection<ProductModel>(ProductModel.products);
            ProductModel.products.CollectionChanged += ChangeMyCollection;
            ClientModel.current.shoppingProducts.CollectionChanged += UpdateToCartButtons;
            ClientModel.current.likedProducts.CollectionChanged += UpdateLikeButtons;
            AddToCartCommand = new Command<Button>((Button sender) =>
            {
                if (ClientModel.current.shoppingProducts.Contains((Content)Products[(sender.BindingContext 
                    as ProductModel).Id]))
                {
                    ClientModel.current.shoppingProducts.Remove((Content)Products[(sender.BindingContext as ProductModel).Id]);
                }
                else
                {
                    ClientModel.current.shoppingProducts.Add((Content)Products[(sender.BindingContext as ProductModel).Id]);
                }
            });

            LikeCommand = new Command<Button>((Button sender) =>
            {
                if (ClientModel.current.likedProducts.Contains(Products[(sender.BindingContext as ProductModel).Id]))
                {
                    ClientModel.current.likedProducts.Remove(Products[(sender.BindingContext as ProductModel).Id]);
                }
                else
                {
                    ClientModel.current.likedProducts.Add(Products[(sender.BindingContext as ProductModel).Id]);
                }
               // Shell.Current.CurrentPage.DisplayAlert("Hi", "Liked", " lok");
            });

        }
        ~CatalogViewModel()
        {
            ProductModel.products.CollectionChanged -= ChangeMyCollection;
            ClientModel.current.shoppingProducts.CollectionChanged -= UpdateToCartButtons;
            ClientModel.current.likedProducts.CollectionChanged -= UpdateLikeButtons;
        }

        public static void ChangeLikeText(Button like)
        {

            if (ClientModel.current.likedProducts.Contains(ProductModel.products[(like.BindingContext as ProductModel).Id]))
            {
                like.Text = "Уже в избранных";
                like.TextColor = Colors.Orange;
                like.Background = Colors.White;
                like.BorderWidth = 5;
            }
            else
            {
                like.Text = "В избранные";
                like.TextColor = Colors.White;
                like.Background = Colors.Orange;
                like.BorderWidth = 0;
            }
        }
        public static void ChangeShoppingText(Button to_cart)
        {

            if (ClientModel.current.shoppingProducts.Contains((Content)ProductModel.products[(to_cart.BindingContext as ProductModel).Id]))
            {
                to_cart.Text = "Уже в корзине";
                to_cart.TextColor = Colors.Green;
                to_cart.Background = Colors.White;
                to_cart.BorderWidth = 5;
            }
            else
            {
                to_cart.Text = "В корзину";
                to_cart.Background = Colors.Green;
                to_cart.BorderWidth = 0;
                to_cart.TextColor = Colors.White;
            }
        }



        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        void ChangeMyCollection(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is ProductModel newProduct)
                        Products.Add(newProduct);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is ProductModel oldProduct)
                        Products.Remove(oldProduct);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is ProductModel replacingProduct) &&
                        (e.OldItems?[0] is ProductModel replacedProduct))
                        Products[ProductModel.products.IndexOf(replacedProduct)] = replacingProduct;
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Products.Clear();
                    break;
            }
        }
        void UpdateToCartButtons(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Content newProduct)
                    {
                        ChangeShoppingText(ToCartButtons[newProduct.ProductId]);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Content oldProduct)
                    {
                        ChangeShoppingText(ToCartButtons[oldProduct.ProductId]);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    for(int i = 0; i < Products.Count; i++)
                    {
                        ChangeShoppingText(ToCartButtons[i]);
                    }
                    break;
            }
        }
        void UpdateLikeButtons(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is ProductModel newProduct)
                    {
                        ChangeLikeText(LikeButtons[newProduct.Id]);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is ProductModel oldProduct)
                    {
                        ChangeLikeText(LikeButtons[oldProduct.Id]);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    for (int i = 0; i < Products.Count; i++)
                    {
                        ChangeLikeText(LikeButtons[i]);
                    }
                    break;
            }
        }
    }
}
