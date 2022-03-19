using DigitalProduct.Application.Products;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Application.Shoppings;
using Microsoft.AspNetCore.Mvc;

namespace DigitalProduct.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingController : ControllerBase
{
    private readonly ILogger<ShoppingController> _logger;
    private readonly IShoppingMediator _shoppingMediator;
    private readonly IProductService _productService;

    public ShoppingController(ILogger<ShoppingController> logger, IShoppingMediator shoppingMediator, IProductService productService)
    {
        _logger = logger;
        _shoppingMediator = shoppingMediator;
        _productService = productService;
    }

    /// <summary>
    /// Uso del Patron Mediator
    /// Ejemplo: Ingresar 1, que es el producto que se va agregar al primer shopping y va a enviar una notificación
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]  
    [Route("addtobasket")]
    public async Task<IActionResult> AddToBasket(int id)
    {
        _logger.LogInformation($"Shopping => AddToBasket | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        await _shoppingMediator.Handle(id);

        return Ok();
    }

    /// <summary>
    /// Retornar un Maestro/Detalle
    /// Ejemplo: Ingresar 1, que es el producto que se va agregar al primer shopping y va a enviar una notificación
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getbyid/{id}")]
    public async Task<ActionResult<MaestroDetalleDto>> GetById(int id)
    {
        _logger.LogInformation($"Shopping => GetById | {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        var maestrodetalle = await _productService.GetById(id);
        return Ok(maestrodetalle);
    }
}
