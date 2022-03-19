namespace DigitalProduct.Core.Domain;

public class ShoppingProduct
{
    public long Id { get; set; }
    
    public long ProductId { get; set; }
    public virtual Product Product { get; set; }

    public long ShoppingId { get; set; }
    public virtual Shopping Shopping { get; set; }
}
