using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Library.Models;
using SampleApp.Library.Services;
using System.Windows.Input;

namespace Maui.Client.ViewModels;

[QueryProperty(nameof(Product.ProductId), nameof(Product.ProductId))]
public class EditProductViewModel : INotifyPropertyChanged
{
    private IProductService productservice;

    private string _productId = string.Empty;
    public string ProductId
    {
        get => _productId;
        set
        {
            Product? product = productservice.GetProductById(value);
            if(product != null)
            {
                _productId = value;
                Name = product.Name;
                Price = product.Price.ToString();
            }
        }
    }

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

    public ICommand SaveCommand { get; }

    public EditProductViewModel(IProductService productService)
    {
        productservice = productService;
        SaveCommand = new Command(SaveProduct);
    }

    private async void SaveProduct()
    {
        // TODO: Validate Price
        // TODO: Call ProductService, change by id.
        // Todo: Validate that name field is not empty.

        await AppShell.Current.GoToAsync("..");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
