using System.Runtime.CompilerServices;
using Platinum_Star.Models;
using Platinum_Star.ViewModels;

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
            (BindingContext as ProductPageViewModel).Product = ProductModel.products[id];
           // ProductImage.Source = ProductModel.products[ProductId].ImageUrl;
            ProductName.Text = ProductModel.products[ProductId].Name;
            ProductDescription.Text = ProductModel.products[ProductId].Description;
            ProductPrice.Text = ProductModel.products[ProductId].Price.ToString();
            OnPropertyChanged();
        }
    }
    public ProductPage()
    {
        InitializeComponent();
        BindingContext = new ProductPageViewModel();
        this.Loaded += (s, e) =>
        {
            ChangeLikeText();
            ChangeShoppingText();
        };
    }


    void ChangeLikeText()
    {
        
        if (ClientModel.current.likedProducts.Contains(ProductModel.products[ProductId]))
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

        if (ClientModel.current.shoppingProducts.Contains(ProductModel.products[ProductId]))
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
        if (ClientModel.current.likedProducts.Contains(ProductModel.products[ProductId]))
        {
            ClientModel.current.likedProducts.Remove(ProductModel.products[ProductId]);
        }
        else
        {
            ClientModel.current.likedProducts.Add(ProductModel.products[ProductId]);
        }
        ChangeLikeText();
    }
    private void AddToCart_Clicked(object sender, System.EventArgs e)
    {
        if (ClientModel.current.shoppingProducts.Contains(ProductModel.products[ProductId]))
        {
            ClientModel.current.shoppingProducts.Remove(ProductModel.products[ProductId]);
        }
        else
        {
            ClientModel.current.shoppingProducts.Add(ProductModel.products[ProductId]);
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