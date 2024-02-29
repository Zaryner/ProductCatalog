using System.Runtime.CompilerServices;

namespace Platinum_Star;

[QueryProperty(nameof(ProductId), "id")]
public partial class ProductPage : ContentPage
{
	int id;
    public int ProductId
    {
        get => id;
        set
        {
            id = value;
            ProductImage.Source = Product.products[ProductId].ImageUrl;
            ProductName.Text = Product.products[ProductId].Name;
            ProductDescription.Text = Product.products[ProductId].Description;
            ProductPrice.Text = Product.products[ProductId].Price.ToString();
            OnPropertyChanged();
        }
    }
    public ProductPage()
	{
		InitializeComponent();
	}
	private async void Back(object sender, System.EventArgs e)
	{
        await Shell.Current.GoToAsync("..");
    }

}