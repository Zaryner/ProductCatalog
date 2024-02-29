namespace Platinum_Star;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("productpage", typeof(ProductPage));
    }
}
