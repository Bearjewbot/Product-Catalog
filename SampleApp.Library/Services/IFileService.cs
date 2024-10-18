using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public interface IFileService
{
    List<Product> ReadFromFile();
    bool WriteToFile(List<Product> products);
}
