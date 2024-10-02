using System;

namespace SampleApp.Library.Models;

public class Product
{
    private Guid ProductId { get; } = Guid.NewGuid();

    public string Name { get; private set; } = null!;

    public int Price { get; private set; }


    public override string ToString()
    {
        return $"Item: {Name} || Price: {Price} || ProductId: {ProductId}";
    }
}
