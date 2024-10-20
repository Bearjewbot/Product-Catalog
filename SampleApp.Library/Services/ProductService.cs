using SampleApp.Library.Enums;
using SampleApp.Library.Models;


namespace SampleApp.Library.Services;

//add a catch in loadProductsfromfile?
//Getproductbyid is ok?
public class ProductService : IProductService
{
    private readonly List<Product> _items = [];
    private readonly IFileService _fileService;


    public ProductService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public Product? GetProductById(string id)
    {
        try
        {
            return _items.FirstOrDefault(product => product.ProductId.Equals(id));
        }
        catch
        {
            return null;
        }
    }

    public StatusCodes AddProduct(string name, string inputPrice)
    {
        var trimmedName = name.Trim();

        try
        {
            if (string.IsNullOrWhiteSpace(trimmedName))
            {
                return StatusCodes.Failed;
            }
            else if (DoesProductExist(trimmedName))
            {
                return StatusCodes.Exists;
            }
            else if (!(double.TryParse(inputPrice, out double price)))
            {
                return StatusCodes.Failed;
            }
            else
            {
                _items.Add(new Product
                {
                    Name = trimmedName,
                    Price = price,
                });
                SaveToFile();

                return StatusCodes.Success;
            }
        }
        catch
        {
            return StatusCodes.Failed;
        }
    }

    public StatusCodes LoadProductsFromFile(List<Product> products)
    {
        try
        {
            if (products.Count != 0)
            {
                _items.AddRange(products);
            }
            return StatusCodes.Success;
        }
        catch
        {
            return StatusCodes.Failed;
        }
    }

    //FIXA
    public StatusCodes DeleteProductById(string id)
    {
        try
        {
            _items.RemoveAll(product => product.ProductId.Equals(id));
            SaveToFile();
            return StatusCodes.Success;
        }
        catch
        {
            return StatusCodes.Failed;
        }
    }

    public StatusCodes UpdateProductById(string name, string inputPrice, string id)
    {

        var trimmedName = name.Trim();

        try
        {
            if (string.IsNullOrWhiteSpace(trimmedName))
            {
                return StatusCodes.Failed;
            }
            else if (DoesProductExist(trimmedName))
            {
                return StatusCodes.Exists;
            }
            else if (!(double.TryParse(inputPrice, out double price)))
            {
                return StatusCodes.Failed;
            }
            else
            {

                int index = _items.FindIndex(product => product.ProductId.Equals(id));

                if (index != -1)
                {
                    _items.RemoveAll(product => product.ProductId.Equals(id));
                    _items.Insert(index, new Product() { Name = trimmedName, Price = price, ProductId = id });
                    SaveToFile();

                    return StatusCodes.Success;
                }

                return StatusCodes.NotFound;
            }
        }
        catch
        {
            return StatusCodes.Failed;
        }
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _items;
    }

    public bool DoesProductExist(string name)
    {
        try
        {
            return _items.Exists(Product => Product.Name.Equals(name.Trim()));
        }
        catch
        {
            return false;
        }
    }

    public void SaveToFile()
    {
        _fileService.WriteToFile(_items);
    }
}
