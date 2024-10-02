using System;
using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public class ProductService
{
    private List<Product> _items = [];

    public void AddProduct(string name, int price)
    {
        bool doesProductExist = _items.Exists(Product => Product.Name.Equals(name));

        if (!doesProductExist)
        {
            _items.Add(new Product
            {
                Name = name,
                Price = price,
            });
        }

        else
            Console.WriteLine("You can't add a product which already exists.");
    }

    public void AddProducts(List<Product> products)
    {
        _items.AddRange(products);
    }

    public int DeleteProductById(Guid id)
    {
        return _items.RemoveAll(product => product.ItemId.Equals(id));
    }

    public void ChangeProductById(string name, int price, Guid id)
    {
        int index = _items.FindIndex(product => product.ItemId.Equals(id));

        if (index != -1)
        {
            _items.Insert(index, new Product() { Name = name, Price = price, ItemId = id });
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


}
