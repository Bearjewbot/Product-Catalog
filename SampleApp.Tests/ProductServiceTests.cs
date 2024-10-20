using SampleApp.Library.Services;

namespace SampleApp.Tests;


public class ProductServiceTests
{
    [Fact]
    public void AddNewProduct_Then_CheckIfAdded()
    {
        //Arrange
        IFileService fileService = new FileService(string.Empty);
        IProductService productService = new ProductService(fileService);
        var objectsBeforeAdding = productService.GetAllProducts().ToList().Count;


        //Act
        productService.AddProduct("John", "3");
        var objectsAfterAdding = productService.GetAllProducts().ToList().Count;

        //Assert
        Assert.True(objectsAfterAdding == (objectsBeforeAdding + 1));
    }


    [Fact]
    public void DeleteProductFromList_Then_ConfirmThatItHasBeenDeleted()
    {
        //Arrange
        IFileService fileservice = new FileService(string.Empty);
        IProductService productService = new ProductService(fileservice);

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
    public void UpdateAProductById_Then_ConfirmThatItHasBeenUpdated()
    {
        //Arrange
        IFileService fileservice = new FileService(string.Empty);
        IProductService productService = new ProductService(fileservice);

        productService.AddProduct("John", "3");
        var productListBeforeUpdate = productService.GetAllProducts().ToList();
        var firstProduct = productListBeforeUpdate.First();
        var productId = firstProduct.ProductId;

        //Act
        productService.UpdateProductById("Denny", "500", productId);
        var productListAfterUpdate = productService.GetAllProducts().ToList();

        //Assert
        Assert.True(productListBeforeUpdate != productListAfterUpdate);


    }
}

