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
            (BindingContext as ProductPageViewModel).SetContext(id);
            OnPropertyChanged();
        }
    }
    public ProductPage()
    {
        BindingContext = new ProductPageViewModel();
        InitializeComponent();
        Appearing += ((object sender, System.EventArgs e) => {
            ClientModel.current.shoppingProducts.CollectionChanged += (BindingContext as ProductPageViewModel).UpdateToCartButton;
            ClientModel.current.likedProducts.CollectionChanged += (BindingContext as ProductPageViewModel).UpdateLikeButton;
            CatalogViewModel.ChangeShoppingText(to_cart);
            CatalogViewModel.ChangeLikeText(like);
        });
        Disappearing += ((object sender, System.EventArgs e) => {
            ClientModel.current.shoppingProducts.CollectionChanged -= (BindingContext as ProductPageViewModel).UpdateToCartButton;
            ClientModel.current.likedProducts.CollectionChanged -= (BindingContext as ProductPageViewModel).UpdateLikeButton;
        });
    
    }
    
    private void ToCartLoaded(object sender, System.EventArgs e)
    {
        CatalogViewModel.ChangeShoppingText(sender as Button);
        (BindingContext as ProductPageViewModel).ToCartButton = sender as Button;
    }
    private void LikeLoaded(object sender, System.EventArgs e)
    {
        CatalogViewModel.ChangeLikeText(sender as Button);
        (BindingContext as ProductPageViewModel).LikeButton = (sender as Button);
    }

    private void ToCartUnloaded(object sender, System.EventArgs e)
    {
        (BindingContext as ProductPageViewModel).ToCartButton = null;
    }
    private void LikeUnloaded(object sender, System.EventArgs e)
    {
        (BindingContext as ProductPageViewModel).LikeButton=null;
    }

}