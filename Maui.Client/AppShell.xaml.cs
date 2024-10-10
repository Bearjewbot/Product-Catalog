using Maui.Client.Views;

namespace Maui.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EditProductPage), typeof(EditProductPage));
        }
    }
}
