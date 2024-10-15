namespace Maui.Client
{
    public partial class App : Application
    {
        private readonly IProductService productService;

        public App(IProductService productService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            this.productService = productService;
        }

        public override void CloseWindow(Window window)
        {
            productService.SaveToFile();
            base.CloseWindow(window);
        }
    }
}
