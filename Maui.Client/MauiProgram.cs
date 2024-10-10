using Microsoft.Extensions.Logging;
using SampleApp.Library.Services;
using Maui.Client.ViewModels;
using Maui.Client.Views;

namespace Maui.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // TODO: Create IFileService interface
            // TODO: Add FileService to depedency injection
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<ProductListPage>();
            builder.Services.AddSingleton<ProductListViewModel>();

            builder.Services.AddTransient<EditProductPage>();
            builder.Services.AddTransient<EditProductViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
