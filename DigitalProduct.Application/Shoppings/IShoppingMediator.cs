namespace DigitalProduct.Application.Shoppings;

public interface IShoppingMediator
{
    Task Handle(long id);
}
