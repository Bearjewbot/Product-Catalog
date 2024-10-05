using SampleApp.Library.Models;
using SampleApp.Library.Services;

namespace Maui.Client;



public partial class MainPage : ContentPage
{

    ProductService productservice = new();



    public MainPage()
    {
        InitializeComponent();




        //listContacts.ItemsSource = products;
        //listContacts.ItemsSource = productservice.GetAllProducts();

    }

    private void BtnAddProduct_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(input_Name.Text))
        {
            DisplayAlert("Error", "You have to fill in the name in order to add a product.", "Try again");
        }
        else if (productservice.DoesProductExist(input_Name.Text))
        {
            DisplayAlert("Error", "You cannot add a product with a name that already exists.", "Try again");
        }
        else if (!(double.TryParse(input_Price.Text, out double price)))
        {
            DisplayAlert("Error", "You have to fill in a price with numbers in order to add a product.", "Try again");
        }
        else
        {

            productservice.AddProduct(input_Name.Text, price);
            listContacts.ItemsSource = null;
            listContacts.ItemsSource = productservice.GetAllProducts();
            input_Name.Text = "";
            input_Price.Text = "";

        }

    }

    private void BtnDeleteProduct_Clicked(object sender, EventArgs e)
    {
        DeleteCommand((Product)BindingContext);
    }

    private void DeleteCommand(Product product)
    {

    }
}


