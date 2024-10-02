using SampleApp.Library.Services;

namespace Maui.Client;



    public partial class MainPage : ContentPage
    {

        ProductService productservice = new();

       

        public MainPage()
        {
            InitializeComponent();

            listContacts.ItemsSource = productservice.GetAllProducts();
            
        }

        private void btnAddProduct_Clicked(object sender, EventArgs e)
        {

        }
    }


