using System;

public class Product
{
    private Guid _productId;

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public Guid ItemId
    {
        get
        {
            _productId = Guid.NewGuid();
            return _productId;
        }
        set { _productId = value; }
    }

    public override string ToString()
    {
        return $"Item: {Name} || Price: {Price} || ItemID: {ItemId}";
    }
}
