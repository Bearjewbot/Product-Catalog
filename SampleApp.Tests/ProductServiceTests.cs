using SampleApp.Library.Enums;
using SampleApp.Library.Models;
using SampleApp.Library.Services;



namespace SampleApp.Tests;


public class ProductServiceTests
{
    [Fact]
    public void AddProduct__Should_CreateANewProductAndThenAddItToAListOfProducts__Return_StatusCodeSuccess()
    {
        //Arrange
        IFileService fileService = new FileService(string.Empty);
        IProductService productService = new ProductService(fileService);
        var objectsBeforeAdding = productService.GetAllProducts().ToList().Count;


        //Act
        var result = productService.AddProduct("John", "3");
        var objectsAfterAdding = productService.GetAllProducts().ToList().Count;

        //Assert
        Assert.True(objectsAfterAdding == (objectsBeforeAdding + 1));
        Assert.True(result == StatusCodes.Success);
    }


    [Fact]
    public void DeleteProduct__Should_DeleteAProductFromAListBasedOnItsId()
    {
        //Arrange
        IFileService fileService = new FileService(string.Empty);
        IProductService productService = new ProductService(fileService);

        productService.AddProduct("John", "3");
        var productList = productService.GetAllProducts().ToList();
        var firstProduct = productList.First();
        var productId = firstProduct.ProductId;

        var objectsBeforeDeleted = productList.Count();

        //Act
        productService.DeleteProductById(productId);
        var objectsAfterDeleted = productService.GetAllProducts().ToList().Count();

        //Assert
        Assert.True(objectsAfterDeleted == (objectsBeforeDeleted - 1));
    }

    [Fact]
    public void UpdateProductById__Should_UpdateAProductInAListBasedOnItsId()
    {
        //Arrange
        IFileService fileservice = new FileService(string.Empty);
        IProductService productService = new ProductService(fileservice);

        productService.AddProduct("John", "3");
        var productBeforeUpdate = productService.GetAllProducts().ToList().First();
        var productId = productBeforeUpdate.ProductId;

        //Act
        productService.UpdateProductById("Denny", "500", productId);
        Product? productAfterUpdate = productService.GetAllProducts().ToList().First();

        //Assert
        Assert.NotNull(productAfterUpdate);
        Assert.NotEqual(productBeforeUpdate.Name, productAfterUpdate.Name);
        Assert.NotEqual(productBeforeUpdate.Price, productAfterUpdate.Price);
    }

    [Fact]
    public void SaveListToFileAndReadFromFile__Should_SaveAListToAFileAndThenReadItFromFile()
    {
        //Arrange
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductList.json");

        IFileService fileService = new FileService(filePath);
        IProductService productService = new ProductService(fileService);

        //Act
        productService.AddProduct("John", "3");
        var savedProductList = fileService.ReadFromFile();

        //Assert
        Assert.NotEmpty(savedProductList);


    }
}

