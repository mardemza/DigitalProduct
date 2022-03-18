using DigitalProduct.Application.Products.Dto;

namespace DigitalProduct.Application.Shopping;

public interface IShoppingService
{
    void AddToBasket(DetalleDto product);
}
