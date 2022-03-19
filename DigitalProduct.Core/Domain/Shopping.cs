namespace DigitalProduct.Core.Domain;

public class Shopping
{
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual IList<ShoppingProduct> ProductShoppings { get; set; } = new List<ShoppingProduct>();
}
