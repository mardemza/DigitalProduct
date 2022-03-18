using DigitalProduct.Application.Products.Dto;

namespace DigitalProduct.Application.Products
{
    public interface IProductService
    {
        Task Insert(ProductInsertDto input);
        Task Update(ProductUpdateDto input);
        Task<MaestroDetalleDto> GetById(long id);
    }
}