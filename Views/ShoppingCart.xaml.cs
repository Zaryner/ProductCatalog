using Platinum_Star.ViewModels;
using Platinum_Star.Models;

namespace Platinum_Star;

public partial class ShoppingCart : ContentPage
{
	public ShoppingCart()
	{
        BindingContext = new CartViewModel();
        InitializeComponent();		
	}

    private void LikeLoaded(object sender, System.EventArgs e)
    {
        CatalogViewModel.ChangeLikeText(sender as Button);
        (BindingContext as CartViewModel).LikeButtons.Add(sender as Button);
    }
 
    private void LikeUnloaded(object sender, System.EventArgs e)
    {
        (BindingContext as CartViewModel).LikeButtons.Remove(sender as Button);
    }
    private async void OnTapped(object sender, System.EventArgs e)
    {
        if (ProductCards.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"productpage?id={(ProductCards.SelectedItem as Content).ProductId}");
        }
    }

}