namespace DigitalProduct.Core.Domain;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual IList<ShoppingProduct> ProductShoppings { get; set; } = new List<ShoppingProduct>();
}
