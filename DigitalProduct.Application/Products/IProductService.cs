using DigitalProduct.Application.Products.Dto;

namespace DigitalProduct.Application.Products
{
    public interface IProductService
    {
        Task<IList<DetalleDto>> GetAll();
        Task Insert(ProductInsertDto input);
        Task Update(long id, ProductUpdateDto input);
        Task<DetalleDto> Get(long id);
        Task Delete(long id);
        Task<MaestroDetalleDto> GetById(long id);
    }
}