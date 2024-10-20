using SampleApp.Library.Enums;
using SampleApp.Library.Models;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(string id);
    bool DoesProductExist(string name);
    StatusCodes AddProduct(string name, string inputPrice);
    StatusCodes LoadProductsFromFile(List<Product> products);
    StatusCodes UpdateProductById(string name, string inputPrice, string id);
    StatusCodes DeleteProductById(string id);
    void SaveToFile();

}