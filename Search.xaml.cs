using Microsoft.Maui.Controls;
using System.Security.Cryptography;
using System.Windows.Input;

namespace Platinum_Star;

public partial class Search : ContentPage
{
	public Search()
	{

       InitializeComponent();
        searchHandler.Products = Product.products;
        ProductCards.ItemsSource = searchHandler.Products;
#if ANDROID||IOS
        ProductCards.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
#else
        ProductCards.ItemsLayout = new GridItemsLayout(6, ItemsLayoutOrientation.Vertical);
#endif
  
    }
//    protected override void OnSizeAllocated(double width, double height)
//    {
//        base.OnSizeAllocated(width, height);

//#if WINDOWS||DEBUG
//        ProductCards.ItemsLayout = new GridItemsLayout((int)(Application.Current.Windows[0].Width/(200+5)), ItemsLayoutOrientation.Vertical);
//#endif
//    }


    private void OnAddToCartClicked(object sender, System.EventArgs e)
    {
        
    }
    private void OnLikeClicked(object sender, System.EventArgs e)
    {

    }

    private async void OnTapped(object sender, System.EventArgs e)
    {
        if (ProductCards.SelectedItem != null)
        {
                await Shell.Current.GoToAsync($"productpage?id={(ProductCards.SelectedItem as Product).Id}");
        }
    }



}