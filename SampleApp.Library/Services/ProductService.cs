using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public class ProductService : IProductService
{
    private List<Product> _items = [];

    public Product? GetProductById(string id)
    {
        return _items.FirstOrDefault(product => product.ProductId.Equals(id));
    }

    public void AddProduct(string name, double price)
    {
        if (!DoesProductExist(name))
        {
            _items.Add(new Product
            {
                Name = name,
                Price = price,
            });
        }
    }

    public void AddProducts(List<Product> products)
    {
        _items.AddRange(products);
    }

    public int DeleteProductById(string id)
    {
        return _items.RemoveAll(product => product.ProductId.Equals(id));
    }

    public void UpdateProductById(string name, double price, string id)
    {
        int index = _items.FindIndex(product => product.ProductId.Equals(id));

        if (name)
        {

        }
        else if (index != -1)
        {
            _items.RemoveAll(product => product.ProductId.Equals(id));
            _items.Insert(index, new Product() { Name = name, Price = price, ProductId = id });
        }
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _items;
    }

    public bool DoesProductExist(string name)
    {
        return _items.Exists(Product => Product.Name.Equals(name.Trim()));
    }

}
