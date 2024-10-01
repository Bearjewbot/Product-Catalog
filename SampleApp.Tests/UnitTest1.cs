namespace SampleApp.Tests;

using CLI.Client.Models;
using CLI.Client.Services;
using Xunit.Abstractions;

public class UnitTest1
{

    // Skapa ett enkelt enhetstest för att säkerställa att produkter kan läggas till i listan och att listan innehåller 
    // rätt antal produkter efter att en ny produkt lagts till.

    [Fact]
    public void Add_NewProduct_ThenCheck_IfAdded()
    {
        //Arrange
        ProductService productService = new();
        var objectsBeforeAdding = productService.GetAllProducts().ToList().Count;
        

        //Act
        productService.AddProduct("John", 3);
        var objectsAfterAdding = productService.GetAllProducts().ToList().Count;

        //Assert
        Assert.True(objectsAfterAdding == (objectsBeforeAdding + 1));
    }


    // Utöka dina enhetstester till att inkludera tester för: Att ta bort en produkt från listan; Att uppdatera en produkt.; 
    // Att spara och läsa in produkter från fil.


    public void RemoveProduct_ThenCheck_IfRemoved()
    {
        
    }
}