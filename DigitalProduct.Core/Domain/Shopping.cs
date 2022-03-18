namespace DigitalProduct.Core.Domain;

public class Shopping
{
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual IList<Product> Products { get; set; } = new List<Product>();
}
