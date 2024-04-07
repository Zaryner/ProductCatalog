using System;
using System.Collections.Generic;
using Platinum_Star.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Platinum_Star.ViewModels
{
    internal class ProductPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ProductModel _product;
        public Button LikeButton;
        public Button ToCartButton;
        public ProductModel Product
        {
            get => _product;
            set
            {
                if (_product != value)
                {
                    _product= value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddToCartCommand { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ICommand RatingCommand { get; set; }

        public ProductPageViewModel()
        {
            AddToCartCommand = new Command<Button>((Button sender) =>
            {
                if (ClientModel.current.shoppingProducts.Contains((Content)Product))
                {
                    ClientModel.current.shoppingProducts.Remove((Content)Product);
                }
                else
                {
                    ClientModel.current.shoppingProducts.Add((Content)Product);
                }
            });

            LikeCommand = new Command<Button>((Button sender) =>
            {
                if (ClientModel.current.likedProducts.Contains(Product))
                {
                    ClientModel.current.likedProducts.Remove(Product);
                }
                else
                {
                    ClientModel.current.likedProducts.Add(Product);
                }
            });
            SubmitCommand = new Command<Button>((Button sender) =>
            {
                Shell.Current.CurrentPage.DisplayAlert("Привет", "Пока не реализованно", " Хорошо");
            });
            RatingCommand = new Command(() =>
            {
                Shell.Current.CurrentPage.DisplayAlert("Привет", "Пока не реализованно ", " Хорошо");
            });
        }


        public void SetContext(int product_id)
        {
            Product = ProductModel.products[product_id];
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void UpdateToCartButton(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Content newProduct)
                    {
                        if (newProduct.Product == Product)
                            CatalogViewModel.ChangeShoppingText(ToCartButton);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Content oldProduct)
                    {
                        if (oldProduct.Product == Product)
                            CatalogViewModel.ChangeShoppingText(ToCartButton);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:

                        CatalogViewModel.ChangeShoppingText(ToCartButton);
                    
                    break;
            }
        }
        public void UpdateLikeButton(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is ProductModel newProduct)
                    {
                        if(newProduct==Product)
                        CatalogViewModel.ChangeLikeText(LikeButton);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is ProductModel oldProduct)
                    {
                        if (oldProduct == Product)
                            CatalogViewModel.ChangeLikeText(LikeButton);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    CatalogViewModel.ChangeLikeText(LikeButton);
                    break;
            }
        }

    }
}
