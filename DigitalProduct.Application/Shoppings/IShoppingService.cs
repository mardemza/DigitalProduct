using DigitalProduct.Application.Products.Dto;

namespace DigitalProduct.Application.Shoppings;

public interface IShoppingService
{
    void AddToBasket(DetalleDto product);
}
