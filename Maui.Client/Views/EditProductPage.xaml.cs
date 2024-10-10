using Maui.Client.ViewModels;

namespace Maui.Client.Views;

public partial class EditProductPage : ContentPage
{
    public EditProductPage(EditProductViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}