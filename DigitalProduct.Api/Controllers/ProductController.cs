using DigitalProduct.Application.Products;
using DigitalProduct.Application.Products.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalProduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: api/<ProductController>
        /// <summary>
        /// GET: api/product
        /// </summary>
        /// <returns>List => DetalleDto</returns>
        [HttpGet]
        public async Task<IEnumerable<DetalleDto>> Get()
        {
            _logger.LogInformation($"Product => GetAll | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            var products = await _productService.GetAll();
            return products;
        }

        // GET api/<ProductController>/5
        /// <summary>
        /// GET api/product/5
        /// </summary>
        /// <param name="id">Tipo long</param>
        /// <returns>DetalleDto</returns>
        [HttpGet("{id}")]
        public async Task<DetalleDto> Get(int id)
        {
            _logger.LogInformation($"Product => Get | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            var product = await _productService.Get(id);
            return product;
        }

        // POST api/<ProductController>
        /// <summary>
        /// POST api/product
        /// </summary>
        /// <param name="value">Tipo ProductInsertDto</param>
        /// <returns>void</returns>
        [HttpPost]
        public async Task Post([FromBody] ProductInsertDto value)
        {
            _logger.LogInformation($"Product => Insert | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            await _productService.Insert(value);
        }

        // PUT api/<ProductController>/5
        /// <summary>
        /// PUT api/product/5
        /// </summary>
        /// <param name="id">Tipo long</param>
        /// <param name="value">Tipo ProductUpdateDto</param>
        /// <returns>void</returns>
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProductUpdateDto value)
        {
            _logger.LogInformation($"Product => Update | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            await _productService.Update(id, value);
        }

        // DELETE api/<ProductController>/5
        /// <summary>
        /// DELETE api/product/5
        /// </summary>
        /// <param name="id">Tipo long</param>
        /// <returns>void</returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Product => Delete | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            await _productService.Delete(id);
        }
    }
}
