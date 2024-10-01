using System;
using System.Text.Json;
using CLI.Client.Models;

namespace CLI.Client.Services;

public class JsonService
{
    internal List<Product> ReadFromFile(string fileName)
    {
        var jsonString = File.ReadAllText(fileName);
        List<Product> jsonList = JsonSerializer.Deserialize<List<Product>>(jsonString)!;     
        return jsonList;     
    }
    internal void WriteToFile(string fileName, List<Product> products) 
    {
        String jsonString = JsonSerializer.Serialize(products); 
        File.WriteAllText(fileName, jsonString);   
    }

}
