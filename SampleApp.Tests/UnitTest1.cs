namespace SampleApp.Tests;

using SampleApp.Library.Services;

public class UnitTest1
{

    private IProductService _productService;
    public UnitTest1(ProductService productService)
    {
        _productService = productService;
    }

    // Skapa ett enkelt enhetstest för att säkerställa att produkter kan läggas till i listan och att listan innehåller 
    // rätt antal produkter efter att en ny produkt lagts till.

    [Fact]
    public void AddNewProduct_Then_CheckIfAdded()
    {
        //Arrange

        var objectsBeforeAdding = _productService.GetAllProducts().ToList().Count;


        //Act
        _productService.AddProduct("John", "3");
        var objectsAfterAdding = _productService.GetAllProducts().ToList().Count;

        //Assert
        Assert.True(objectsAfterAdding == (objectsBeforeAdding + 1));
    }


    // Utöka dina enhetstester till att inkludera tester för: Att ta bort en produkt från listan; Att uppdatera en produkt.; 
    // Att spara och läsa in produkter från fil.



}