using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls;

namespace Platinum_Star;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        Label titleLabel = new Label
        {
            Text = "THE BLACK CAT by Edgar Allan Poe",
            // More properties set here to define the Label appearance
        };

        StackLayout stackLayout = new StackLayout();
        stackLayout.Add(new Label { Text = "FOR the most wild, yet most homely narrative which I am about to pen, I neither expect nor solicit belief. Mad indeed would I be to expect it, in a case where my very senses reject their own evidence. Yet, mad am I not -- and very surely do I not dream. But to-morrow I die, and to-day I would unburthen my soul. My immediate purpose is to place before the world, plainly, succinctly, and without comment, a series of mere household events. In their consequences, these events have terrified -- have tortured -- have destroyed me. Yet I will not attempt to expound them. To me, they have presented little but Horror -- to many they will seem less terrible than barroques. Hereafter, perhaps, some intellect may be found which will reduce my phantasm to the common-place -- some intellect more calm, more logical, and far less excitable than my own, which will perceive, in the circumstances I detail with awe, nothing more than an ordinary succession of very natural causes and effects." });
        // More Label objects go here

        ScrollView scrollView = new ScrollView();
        scrollView.Content = stackLayout;
        // ...

        Title = "";
        Grid grid = new Grid
        {
            Margin = new Thickness(20),
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) }
            }
        };
        grid.Add(titleLabel);
        grid.Add(scrollView, 0, 1);

        ImageButton search = new ImageButton
        {
            Source = "search.png",
            HeightRequest = 35,
            WidthRequest = 35,
            Shadow = new Shadow()      
        };
        search.Clicked += async (s, e) =>
        {

        };
        ImageButton shop = new ImageButton
        {
            Source = "shopping_cart.png",
            HeightRequest = 35,
            WidthRequest = 35,
            Shadow = new Shadow(),
            
        };
        ImageButton person = new ImageButton
        {
            Source = "person.png",
            MinimumHeightRequest = 35,
            MaximumHeightRequest = 135,
            WidthRequest = 35,
            Shadow = new Shadow()
        };

        Grid menu = new Grid
        {
            BackgroundColor = Color.FromRgba(225, 225, 225, 225),
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            },
            ColumnDefinitions =
            {
                new ColumnDefinition{Width=new GridLength(35, GridUnitType.Star)},
                new ColumnDefinition{Width=new GridLength(35,GridUnitType.Star)},
                new ColumnDefinition{Width=new GridLength(35, GridUnitType.Star)},
            }
        };
        menu.Add(search,0,0);
        menu.Add(shop, 1, 0);
        menu.Add(person, 2, 0);

        grid.Add(menu, 0, 2);

        Content = grid;
    }


}

