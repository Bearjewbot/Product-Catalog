using SampleApp.Library.Enums;
using SampleApp.Library.Models;
using System.Text.Json;

namespace SampleApp.Library.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    public List<Product> ReadFromFile()
    {
        try
        {
            if (Path.Exists(_filePath))
            {
                var jsonString = File.ReadAllText(_filePath);
                List<Product> jsonList = JsonSerializer.Deserialize<List<Product>>(jsonString) ?? [];
                return jsonList;
            }
            return [];
        }
        catch
        {
            return [];
        }
    }
    public StatusCodes WriteToFile(List<Product> products)
    {
        try
        {
            String jsonString = JsonSerializer.Serialize(products);
            File.WriteAllText(_filePath, jsonString);
            return StatusCodes.Success;
        }
        catch
        {
            return StatusCodes.Failed;
        }
    }

}
