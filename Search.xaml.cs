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
        searchHandler.Products = ProductModel.products;
        ProductCards.ItemsSource = searchHandler.Products;
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

    void ChangeLikeText(Button like)
    {

        if (ClientModel.current.likedProducts.Contains(ProductModel.products[(like.BindingContext as ProductModel).Id]))
        {
            like.Text = "Уже в избранных";
            like.TextColor = Colors.Orange;
            like.Background = Colors.White;
            like.BorderWidth = 5;
        }
        else
        {
            like.Text = "В избранные";
            like.TextColor = Colors.White;
            like.Background = Colors.Orange;
            like.BorderWidth = 0;
        }
    }
    void ChangeShoppingText(Button to_cart)
    {

        if (ClientModel.current.shoppingProducts.Contains(ProductModel.products[(to_cart.BindingContext as ProductModel).Id]))
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


    private void ToCartLoaded(object sender, System.EventArgs e)
    {
        ChangeShoppingText(sender as Button);
    }
    private void LikeLoaded(object sender, System.EventArgs e)
    {
        ChangeLikeText(sender as Button);
    }
    private void OnAddToCartClicked(object sender, System.EventArgs e)
    {
        if (ClientModel.current.shoppingProducts.Contains(ProductModel.products[((sender as Button).BindingContext as ProductModel).Id]))
        {
            ClientModel.current.shoppingProducts.Remove(ProductModel.products[((sender as Button).BindingContext as ProductModel).Id]);
        }
        else
        {
            ClientModel.current.shoppingProducts.Add(ProductModel.products[((sender as Button).BindingContext as ProductModel).Id]);
        }
        ChangeShoppingText(sender as Button);
    }
    private void OnLikeClicked(object sender, System.EventArgs e)
    {

        if (ClientModel.current.likedProducts.Contains(ProductModel.products[((sender as Button).BindingContext as ProductModel).Id]))
        {
            ClientModel.current.likedProducts.Remove(ProductModel.products[((sender as Button).BindingContext as ProductModel).Id]);
        }
        else
        {
            ClientModel.current.likedProducts.Add(ProductModel.products[((sender as Button).BindingContext as ProductModel).Id]);
        }
        ChangeLikeText(sender as Button);
    }

    private async void OnTapped(object sender, System.EventArgs e)
    {
        if (ProductCards.SelectedItem != null)
        {
                await Shell.Current.GoToAsync($"productpage?id={(ProductCards.SelectedItem as ProductModel).Id}");
        }
    }



}