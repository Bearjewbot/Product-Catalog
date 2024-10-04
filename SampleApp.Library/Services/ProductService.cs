using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public class ProductService
{
    private List<Product> _items = [];

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

    public int DeleteProductById(Guid id)
    {
        return _items.RemoveAll(product => product.ProductId.Equals(id));
    }

    public void ChangeProductById(string name, int price, string id)
    {


        int index = _items.FindIndex(product => product.ProductId.Equals(id));

        if (index != -1)
        {
            _items.Insert(index, new Product() { Name = name, Price = price }); //ProductId = id });
        }
    }

    public void PrintList()
    {
        _items.ForEach(product => Console.WriteLine(product));
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _items;
    }

    public bool DoesProductExist(string name)
    {
        return _items.Exists(Product => Product.Name.Equals(name));
    }

}
