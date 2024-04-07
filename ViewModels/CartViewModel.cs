using Platinum_Star.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platinum_Star.ViewModels
{
    internal class CartViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Content> Products { get; set; }
        public ObservableCollection<Button> LikeButtons { get; set; }
        public ICommand DeleteCommand { get; set; }
        public CartViewModel()
        {
            Products = new ObservableCollection<Content>(ClientModel.current.shoppingProducts);
            ClientModel.current.shoppingProducts.CollectionChanged += ChangeMyCollection;
            ClientModel.current.likedProducts.CollectionChanged += UpdateLikeButtons;
            DeleteCommand = new Command<Button>((Button sender) =>
            {
                if (ClientModel.current.shoppingProducts.Contains(sender.BindingContext as Content))
                {
                    ClientModel.current.shoppingProducts.Remove(sender.BindingContext as Content);
                }
            });
        }
        ~CartViewModel()
        {
            ClientModel.current.shoppingProducts.CollectionChanged -= ChangeMyCollection;
            ClientModel.current.likedProducts.CollectionChanged -= UpdateLikeButtons;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        void ChangeMyCollection(object? sender, NotifyCollectionChangedEventArgs e)
        {          
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Content newContent)
                        Products.Add(newContent);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Content oldContent)
                        Products.Remove(oldContent);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is Content replacingContent) &&
                        (e.OldItems?[0] is Content replacedContent))
                        Products[ClientModel.current.shoppingProducts.IndexOf(replacedContent)] = replacingContent;
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Products.Clear();
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
                       CatalogViewModel.ChangeLikeText(LikeButtons[newProduct.Id]);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is ProductModel oldProduct)
                    {
                        CatalogViewModel.ChangeLikeText(LikeButtons[oldProduct.Id]);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    for (int i = 0; i < Products.Count; i++)
                    {
                        CatalogViewModel.ChangeLikeText(LikeButtons[i]);
                    }
                    break;
            }
        }
    }
}

