using SampleApp.Library.Enums;
using SampleApp.Library.Models;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(string id);
    bool DoesProductExist(string name);
    StatusCodes AddProduct(string name, string inputPrice);
    void LoadProductsFromFile(List<Product> products);
    StatusCodes UpdateProductById(string name, string inputPrice, string id);
    void DeleteProductById(string id);
    void SaveToFile();

}