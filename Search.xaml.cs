using System.Security.Cryptography;

namespace Platinum_Star;

public partial class Search : ContentPage
{
	public Search()
	{

       InitializeComponent();
        searchHandler.Products = Product.products;
        ProductCards.ItemsSource = searchHandler.Products;
    }

    private void OnAddToCartClicked(object sender, System.EventArgs e)
    {
        
    }
    private void OnLikeClicked(object sender, System.EventArgs e)
    {

    }
}