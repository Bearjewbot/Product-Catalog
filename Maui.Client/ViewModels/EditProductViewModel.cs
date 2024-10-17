using SampleApp.Library.Enums;
using SampleApp.Library.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.Client.ViewModels;

//Add the exercise page as a reference for my knowledge of MVVM concept.
//Fix so that if you don't get "name already exists" if you only change the price.
//fix so that enter button is connected to Save.
//create Cancel button.

[QueryProperty(nameof(Product.ProductId), nameof(Product.ProductId))]
public class EditProductViewModel : INotifyPropertyChanged
{
    private IProductService _productService;

    private string _productId = null!;
    public string ProductId
    {
        get => _productId;
        set
        {
            Product? product = _productService.GetProductById(value);
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

    public ICommand SaveCommand { get; }

    public ICommand CancelCommand { get; }

    public EditProductViewModel(IProductService productService)
    {
        _productService = productService;
        SaveCommand = new Command(SaveProduct);
        CancelCommand = new Command(ReturnToMainPage);
    }

    private async void SaveProduct()
    {

        var result = _productService.UpdateProductById(Name, Price, ProductId);

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
            await AppShell.Current.GoToAsync("..");
        }
    }

    private async void ReturnToMainPage()
    {
        await AppShell.Current.GoToAsync("..");

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
