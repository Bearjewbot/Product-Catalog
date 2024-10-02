using System;
using System.Text.Json;
using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public class FileService
{
    public List<Product> ReadFromFile(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        List<Product> jsonList = JsonSerializer.Deserialize<List<Product>>(jsonString)!;
        return jsonList;
    }
    public void WriteToFile(string fileName, List<Product> products)
    {
        String jsonString = JsonSerializer.Serialize(products);
        File.WriteAllText(fileName, jsonString);
    }

}
