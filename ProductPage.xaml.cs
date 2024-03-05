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
        this.Loaded += (s, e) =>
        {
            ChangeLikeText();
            ChangeShoppingText();
        };
    }


    void ChangeLikeText()
    {
        
        if (Client.current.likedProducts.Contains(Product.products[ProductId]))
        {
            like.Text = "Уже в избранных";
            like.TextColor = Colors.Orange;
            like.Background = Colors.White;
            like.BorderWidth = 5;
        }
        else
        {
            like.Text = "В избранные";
            like.TextColor= Colors.White;
            like.Background = Colors.Orange;
            like.BorderWidth = 0;
       }
    }
    void ChangeShoppingText()
    {

        if (Client.current.shoppingProducts.Contains(Product.products[ProductId]))
        {
            to_cart.Text = "Уже в корзине";
            to_cart.TextColor = Colors.Green;
            to_cart.Background = Colors.White;
            to_cart.BorderWidth = 5;
        }
        else
        {
           to_cart.Text = "В корзину";
            to_cart.Background = Colors.Green;
            to_cart.BorderWidth = 0;
            to_cart.TextColor = Colors.White;
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
        ChangeLikeText();
    }
    private void AddToCart_Clicked(object sender, System.EventArgs e)
    {
        if (Client.current.shoppingProducts.Contains(Product.products[ProductId]))
        {
            Client.current.shoppingProducts.Remove(Product.products[ProductId]);
        }
        else
        {
            Client.current.shoppingProducts.Add(Product.products[ProductId]);
        }
        ChangeShoppingText();
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