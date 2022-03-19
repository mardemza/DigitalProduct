namespace DigitalProduct.Application.Clients;

public interface IClient
{
    Task<string> Get(string url);
}
