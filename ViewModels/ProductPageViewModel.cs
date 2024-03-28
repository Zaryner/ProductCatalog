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

        public ProductModel Product { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand LikeCommand { get; set; }

        public ProductPageViewModel()
        {
           

        }



        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
