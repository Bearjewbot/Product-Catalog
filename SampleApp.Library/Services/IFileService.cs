using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public interface IFileService
{
    List<Product> ReadFromFile();
    void WriteToFile(List<Product> products);
}
