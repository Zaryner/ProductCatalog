using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Security.Cryptography;
using System.Windows.Input;
using Platinum_Star.Models;

namespace Platinum_Star;

public partial class Search : ContentPage
{
	public Search()
	{

       InitializeComponent();
        BindingContext = new CatalogViewModel();
        searchHandler.Products = ProductModel.products;
#if ANDROID||IOS
        ProductCards.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
#else
        ProductCards.ItemsLayout = new GridItemsLayout(6, ItemsLayoutOrientation.Vertical);
#endif      
        this.NavigatedTo += (object sender, NavigatedToEventArgs e) =>
        {
            DisplayAlert(" "," "," ");
        };
    }



    private void ToCartLoaded(object sender, System.EventArgs e)
    {
        (BindingContext as CatalogViewModel).ChangeShoppingText(sender as Button);
    }
    private void LikeLoaded(object sender, System.EventArgs e)
    {
        (BindingContext as CatalogViewModel).ChangeLikeText(sender as Button);
    }

    private async void OnTapped(object sender, System.EventArgs e)
    {
        if (ProductCards.SelectedItem != null)
        {
                await Shell.Current.GoToAsync($"productpage?id={(ProductCards.SelectedItem as ProductModel).Id}");
        }
    }



}