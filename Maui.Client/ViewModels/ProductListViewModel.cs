﻿using Maui.Client.Views;
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
        _productService.AddProducts(_fileService.ReadFromFile());
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
        else if (_productService.DoesProductExist(Name))
        {
            Shell.Current.DisplayAlert("Error", "A product with that name already exists.", "Try again");
        }
        else if (!(double.TryParse(Price, out double price)))
        {
            Shell.Current.DisplayAlert("Error", "You have to fill in a price with numbers in order to add a product.", "Try again");
        }
        else
        {
            _productService.AddProduct(Name.Trim(), price);

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

    private void PopulateProducts()
    {
        Product[] fetchedProducts = _productService.GetAllProducts().ToArray();

        Products.Clear();
        foreach (Product product in fetchedProducts)
        {
            Products.Add(product);
        }
    }





}