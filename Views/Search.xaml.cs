using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Security.Cryptography;
using System.Windows.Input;
using Platinum_Star.Models;
using Platinum_Star.ViewModels;

namespace Platinum_Star;

public partial class Search : ContentPage
{
	public Search()
	{
        BindingContext = new CatalogViewModel();
        InitializeComponent();
       // BindingContext = new CatalogViewModel();
        searchHandler.Products = ProductModel.products;
#if ANDROID||IOS
        ProductCards.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
#else
        ProductCards.ItemsLayout = new GridItemsLayout(6, ItemsLayoutOrientation.Vertical);
#endif      
        this.NavigatedTo += (object sender, NavigatedToEventArgs e) =>
        {
            
        };
    }



    private void ToCartLoaded(object sender, System.EventArgs e)
    {
        CatalogViewModel.ChangeShoppingText(sender as Button);
        (BindingContext as CatalogViewModel).ToCartButtons.Add(sender as Button);
    }
    private void LikeLoaded(object sender, System.EventArgs e)
    {
        CatalogViewModel.ChangeLikeText(sender as Button);
        (BindingContext as CatalogViewModel).LikeButtons.Add(sender as Button);
    }
    private void ToCartUnloaded(object sender, System.EventArgs e)
    {
        (BindingContext as CatalogViewModel).ToCartButtons.Remove(sender as Button);
    }
    private void LikeUnloaded(object sender, System.EventArgs e)
    {
        (BindingContext as CatalogViewModel).LikeButtons.Remove(sender as Button);
    }

    private async void OnTapped(object sender, System.EventArgs e)
    {
        if (ProductCards.SelectedItem != null)
        {
                await Shell.Current.GoToAsync($"productpage?id={(ProductCards.SelectedItem as ProductModel).Id}");
        }
    }




}