using SampleApp.Library.Enums;
using SampleApp.Library.Models;

namespace SampleApp.Library.Services;

public interface IFileService
{
    List<Product> ReadFromFile();
    StatusCodes WriteToFile(List<Product> products);
}
