using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Core.Domain;

namespace DigitalProduct.Application.Shoppings;

public class ShoppingService : IShoppingService
{
    private readonly IGenericRepository<Shopping> _shoppingRepository;
    private readonly IGenericRepository<ShoppingProduct> _shoppingProductRepository;

    public ShoppingService(IGenericRepository<Shopping> shoppingRepository,
                           IGenericRepository<ShoppingProduct> shoppingProductRepository)
    {
        _shoppingRepository = shoppingRepository;
        _shoppingProductRepository = shoppingProductRepository;
    }
    public void AddToBasket(DetalleDto product)
    {
        var shopping = _shoppingRepository.GetAll().FirstOrDefault();
        if (shopping == null)
        {
            shopping = new Shopping()
            {
                Name = "Shopping 1"
            };
            _shoppingRepository.Add(shopping);
        }

        _shoppingProductRepository.Add(new ShoppingProduct
        {
            ProductId = product.Id,
            ShoppingId = shopping.Id
        });
    }
}
