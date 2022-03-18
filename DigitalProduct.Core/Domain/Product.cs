namespace DigitalProduct.Core.Domain;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public long ShoppingId { get; set; }
    public virtual Shopping Shopping { get; set; }
}
