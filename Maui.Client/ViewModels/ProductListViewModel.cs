using Maui.Client.Views;
using SampleApp.Library.Enums;
using SampleApp.Library.Models;
using SampleApp.Library.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.Client.ViewModels;

public class ProductListViewModel : INotifyPropertyChanged
{
    private IProductService _productService;
    private IFileService _fileService;

    public ObservableCollection<Product> Products { get; }

    private string _name = null!;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private string _price = null!;
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
    public ICommand UpdateProductCommand { get; }

    public ProductListViewModel(IProductService productService, IFileService fileService)
    {
        _productService = productService;
        _fileService = fileService;

        Products = [];

        AddCommand = new Command(AddProduct);
        DeleteCommand = new Command<Product>(DeleteProduct);
        UpdateProductCommand = new Command<Product>(NavigateToEditProductPage);

    }


    public void OnAppearing()
    {

        _productService.LoadProductsFromFile(_fileService.ReadFromFile());
        PopulateProducts();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //Gör addproduct async.
    public async void AddProduct()
    {
        var result = _productService.AddProduct(Name, Price);

        if (result == StatusCodes.Failed)
        {
            await AppShell.Current.DisplayAlert("Error", "There was an error, try to fill in both fields. Only numbers are allowed in the numbers field.", "Close");
        }
        else if (result == StatusCodes.Exists)
        {
            await AppShell.Current.DisplayAlert("Error", "A product with that name already exists, try again.", "Close");
        }
        else
        {
            Name = "";
            Price = "";

            PopulateProducts();
        }
    }

    public void DeleteProduct(Product product)
    {
        _productService.DeleteProductById(product.ProductId);
        PopulateProducts();
    }

    public async void NavigateToEditProductPage(Product product)
    {
        await AppShell.Current.GoToAsync($"{nameof(EditProductPage)}?{nameof(Product.ProductId)}={product.ProductId}");
    }


    /// <summary>
    ///  Ha kvar detta async?
    /// </summary>
    private async void PopulateProducts()
    {
        Product[] fetchedProducts = await Task.Run(() => _productService.GetAllProducts().ToArray());

        Products.Clear();
        foreach (Product product in fetchedProducts)
        {
            Products.Add(product);
        }
    }





}