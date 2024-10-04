namespace SampleApp.Library.Models;

public class Product
{
    public string ProductId { get; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = null!;

    public double Price { get; set; }


    public override string ToString()
    {
        return $"Item: {Name} || Price: {Price} || ProductId: {ProductId}";
    }
}
