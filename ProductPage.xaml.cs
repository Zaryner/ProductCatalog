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
        ChangeLikeIcon();

    }


    void ChangeLikeIcon()
    {
        if (Client.current.likedProducts.Contains(Product.products[ProductId]))
        {
            like.Source = "like1.png";
        }
        else
        {
            like.Source = "like2.png";
        }
    }
    private async void Back(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    private void FavoriteButton_Clicked(object sender, System.EventArgs e)
    {
        if (Client.current.likedProducts.Contains(Product.products[ProductId]))
        {
            Client.current.likedProducts.Remove(Product.products[ProductId]);
        }
        else
        {
            Client.current.likedProducts.Add(Product.products[ProductId]);
        }
        ChangeLikeIcon();
    }
    private async void AddToCart_Clicked(object sender, System.EventArgs e)
    {
        // await Shell.Current.GoToAsync("..");
    }
    private async void SubmitComment_Clicked(object sender, System.EventArgs e)
    {
        //  await Shell.Current.GoToAsync("..");
    }
    private async void CommentRating_ValueChanged(object sender, System.EventArgs e)
    {
        //  await Shell.Current.GoToAsync("..");
    }

}