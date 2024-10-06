using Maui.Client.ViewModels;

namespace Maui.Client;

public partial class MainPage : ContentPage
{
    private ProductListViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        _viewModel = new ProductListViewModel();
        BindingContext = _viewModel;
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}
