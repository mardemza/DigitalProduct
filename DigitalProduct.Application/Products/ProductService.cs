using DigitalProduct.Application.Clients;
using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Core.Domain;
using System.Text.Json;

namespace DigitalProduct.Application.Products;

public class ProductService: IProductService
{
    private readonly IGenericRepository<Product> _productRepository;    
    private readonly IClient _client;

    public ProductService(IGenericRepository<Product> productRepository,
                          IClient client)
    {
        _productRepository = productRepository;
        _client = client;
    }

    /// <summary>
    /// Retorna una lista de DetalleDto
    /// </summary>
    /// <returns>List => DetalleDto</returns>
    public async Task<IList<DetalleDto>> GetAll()
    {

        var products = _productRepository.GetAll();
        var result = products.Select(product => new DetalleDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description
        }).ToList();

        return await Task.FromResult(result);
    }

    /// <summary>
    /// Retorna un DetalleDto por un ID
    /// </summary>
    /// <param name="id">Tipo long</param>
    /// <returns>DetalleDto</returns>
    public async Task<DetalleDto> Get(long id)
    {
        
        var product = _productRepository.Get(id);

        var result = new DetalleDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description
        };

        return await Task.FromResult(result);
    }

    /// <summary>
    /// Inserta un producto
    /// </summary>
    /// <param name="input">Tipo ProductInsertDto</param>
    /// <returns>void</returns>
    public async Task Insert(ProductInsertDto input)
    {
        var product = new Product()
        {
            Name = input.Name,
            Description = input.Description
        };

        await Task.Run(async () => _productRepository.Add(product));
    }

    /// <summary>
    /// Actualiza un producto
    /// </summary>
    /// <param name="input">Tipo ProductUpdateDto</param>
    /// <returns>void</returns>
    public async Task Update(long id,ProductUpdateDto input)
    {
        var product = _productRepository.Get(id);
        product.Description = input.Description;
        product.Name = input.Name;

        await Task.Run(async () => _productRepository.Update(product));
    }

    /// <summary>
    /// Borra un producto
    /// </summary>
    /// <param name="id">Tipo long</param>
    /// <returns>void</returns>
    public async Task Delete(long id)
    {
        var product = _productRepository.Get(id);
        
        if (product != null)
            await Task.Run(async () => _productRepository.Remove(product));
    }

    public async Task<MaestroDetalleDto> GetById(long id)
    {
        var result = new MaestroDetalleDto
        {
            Detalle = await Get(id),
            Maestro = await GetMaestro()
        };

        return result;
    }

    private async Task<MaestroDto> GetMaestro()
    {        
        var response = await _client.Get("https://gorest.co.in/public/v2/users/2421");
        var result = JsonSerializer.Deserialize<MaestroDto>(response);
        return result;
    }
}
