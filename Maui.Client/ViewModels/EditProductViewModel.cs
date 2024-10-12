using SampleApp.Library.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.Client.ViewModels;

//Fix so that if you don't get "name already exists" if you only change the price.
//fix so that enter button is connected to Save.
//create Cancel button.

[QueryProperty(nameof(Product.ProductId), nameof(Product.ProductId))]
public class EditProductViewModel : INotifyPropertyChanged
{
    private IProductService productService;

    private string _productId = null!;
    public string ProductId
    {
        get => _productId;
        set
        {
            Product? product = productService.GetProductById(value);
            if (product != null)
            {
                _productId = value;
                Name = product.Name;
                Price = product.Price.ToString();
            }
        }
    }

    private string _name = null!;

    public string Name
    {
        get => _name;
        set
        {
            _name = value.Trim();
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

    public ICommand SaveCommand { get; }

    public EditProductViewModel(IProductService _productService)
    {
        productService = _productService;
        SaveCommand = new Command(SaveProduct);
    }

    private async void SaveProduct()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            await AppShell.Current.DisplayAlert("Error", "You have to fill in the name in order to update a product.", "Try again");
        }
        else if (productService.DoesProductExist(Name))
        {
            await AppShell.Current.DisplayAlert("Error", "A product with that name already exists.", "Try again");
        }
        else if (!(double.TryParse(Price, out double price)))
        {
            await AppShell.Current.DisplayAlert("Error", "You need to write a price with numbers.", "Try again");
        }
        else
        {
            productService.UpdateProductById(Name, price, ProductId);
            await AppShell.Current.GoToAsync("..");
        }


    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
