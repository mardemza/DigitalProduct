namespace DigitalProduct.Application.Shopping;

public interface IShoppingMediator
{
    Task Handle(long id);
}
