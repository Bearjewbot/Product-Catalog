using SampleApp.Library.Models;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(string id);
    bool DoesProductExist(string name);
    void AddProduct(string name, double price);
    void AddProducts(List<Product> products);
    void UpdateProductById(string name, double price, string id);
    int DeleteProductById(string id);
}