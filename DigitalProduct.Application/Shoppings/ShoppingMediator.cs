using DigitalProduct.Application.Notifications;
using DigitalProduct.Application.Products;

namespace DigitalProduct.Application.Shoppings;

public class ShoppingMediator : IShoppingMediator
{
    private readonly IProductService _productService;
    private readonly INotificationService _notificationService;
    private readonly IShoppingService _shoppingService;

    public ShoppingMediator(
        IProductService productService,
        INotificationService notificationService,
        IShoppingService shoppingService)
    {
        _productService = productService;
        _notificationService = notificationService;
        _shoppingService = shoppingService;
    }

    public async Task Handle(long id)
    {
        // Fetch Product from Database
        var product = await _productService.Get(id);
        
        // Add Product to Basket
        _shoppingService.AddToBasket(product);

        // Send Notification to User
        _notificationService.SendNotification(product);
    }
}
