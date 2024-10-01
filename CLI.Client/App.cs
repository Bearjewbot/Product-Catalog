using System;
using System.Linq.Expressions;
using CLI.Client.Models;
using CLI.Client.Services;

namespace CLI.Client;

public class App
{
    public string _nameInput = "Donny"; 
    public int _priceInput = 9;


    ProductService productList = new();
    JsonService file = new();

    internal void Run ()
    {
        productList.AddProduct(_nameInput, _priceInput);
        

        //Adds the products from a previous file to the in-memory list.
        List<Product> products = file.ReadFromFile("ProductList.json")!;
        
        productList.AddProducts(products);

        //Delete product by the ID that will be contributed to the method through MAUI application. The method returns the number of deleted items.
        //var deletedItems = productList.DeleteProductById(Guid.Empty);

        //Write to Json file.
        file.WriteToFile("ProductList.json", productList.GetAllProducts().ToList());

        //Update the name and price of a product from the list 
        //string newNameInput = Console.ReadLine()!;
        //int newPriceInput = 4;
        //productList.ChangeProductById(newNameInput, newPriceInput, Guid.Empty);

        //Print the objects in the list
        productList.PrintList();
        
        Console.ReadLine();
    }

}
