using Maui.Client.ViewModels;
using Maui.Client.Views;
using Microsoft.Extensions.Logging;
using SampleApp.Library.Services;

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





            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<ProductListPage>();
            builder.Services.AddSingleton<ProductListViewModel>();

            var baseDirectory = FileSystem.AppDataDirectory;
            var filePath = Path.Combine(baseDirectory, "ProductList.json");
            builder.Services.AddSingleton<IFileService, FileService>(serviceProvider => new FileService(filePath));

            builder.Services.AddTransient<EditProductPage>();
            builder.Services.AddTransient<EditProductViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
