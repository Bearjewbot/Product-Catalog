using SampleApp.Library.Models;
using SampleApp.Library.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

// View - MainPage.xaml
// ViewModel - ProductListViewModel
// Model - ProductService

namespace Maui.Client.ViewModels;

public class ProductListViewModel : INotifyPropertyChanged
{
    private ProductService productservice = new();

    public ObservableCollection<Product> Products { get; }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private string _price = string.Empty;
    public string Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public ProductListViewModel()
    {
        Products = [];

        AddCommand = new Command(AddProduct);
        DeleteCommand = new Command<Product>(DeleteProduct);
    }

    public void OnAppearing()
    {
        PopulateProducts();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void AddProduct()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            Shell.Current.DisplayAlert("Error", "You have to fill in the name in order to add a product.", "Try again");
        }
        else if (productservice.DoesProductExist(Name))
        {
            Shell.Current.DisplayAlert("Error", "You cannot add a product with a name that already exists.", "Try again");
        }
        else if (!(double.TryParse(Price, out double price)))
        {
            Shell.Current.DisplayAlert("Error", "You have to fill in a price with numbers in order to add a product.", "Try again");
        }
        else
        {

            productservice.AddProduct(Name, price);

            Name = "";
            Price = "";

            PopulateProducts();
        }
    }

    public void DeleteProduct(Product product)
    {
        productservice.DeleteProductById(product.ProductId);
        PopulateProducts();
    }

    private void PopulateProducts()
    {
        Product[] fetchedProducts = productservice.GetAllProducts().ToArray();

        Products.Clear();
        foreach (Product product in fetchedProducts)
        {
            Products.Add(product);
        }
    }

    

}