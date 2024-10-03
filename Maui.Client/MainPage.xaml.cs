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

        if (input_Name.Text != null && input_Price.Text != null!) 
        {
            //productservice.AddProduct(input_Name.Text, input_Price.Text); 

        }


    }
}


