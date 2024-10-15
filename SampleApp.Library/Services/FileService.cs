using SampleApp.Library.Models;
using System.Text.Json;

namespace SampleApp.Library.Services;

public class FileService : IFileService
{
    private readonly string filePath;

    public FileService(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Product> ReadFromFile()
    {
        if (Path.Exists(filePath))
        {
            var jsonString = File.ReadAllText(filePath);
            List<Product> jsonList = JsonSerializer.Deserialize<List<Product>>(jsonString) ?? [];
            return jsonList;
        }

        return [];
    }
    public void WriteToFile(List<Product> products)
    {
        String jsonString = JsonSerializer.Serialize(products);
        File.WriteAllText(filePath, jsonString);
    }

}
