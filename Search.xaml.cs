namespace Platinum_Star;

public partial class Search : ContentPage
{
	public Search()
	{

       InitializeComponent();
        searchHandler.Products = Product.products;
    }
}