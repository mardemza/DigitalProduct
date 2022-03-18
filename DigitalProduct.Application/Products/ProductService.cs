using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Core.Domain;

namespace DigitalProduct.Application.Products;

public class ProductService: IProductService
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<MaestroDetalleDto> GetById(long id)
    {
        
        var product = _productRepository.Get(id);

        var result = new MaestroDetalleDto
        {
            Detalle = new DetalleDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            }
        };

        return await Task.FromResult(result);
    }

    public async Task Insert(ProductInsertDto input)
    {
        var product = new Product()
        {
            Name = input.Name,
            Description = input.Description
        };

        await Task.Run(async () => _productRepository.Add(product));
    }

    public async Task Update(ProductUpdateDto input)
    {
        var product = _productRepository.Get(input.Id);
        product.Description = input.Description;
        product.Name = input.Name;

        await Task.Run(async () => _productRepository.Update(product));
    }
}
