using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CarritoCompraController : Controller, ICarritoCompraController
    {
        private ICarritoCompraBW _carritoCompraBW;
        private readonly ILogger<CarritoCompraController> _logger;

        public CarritoCompraController(ICarritoCompraBW carritoCompraBW, ILogger<CarritoCompraController> logger)
        {
            _logger = logger;
            _carritoCompraBW = carritoCompraBW;
        }

        [HttpPost]
        public async Task<IActionResult> PostProductoCarritoAsync([FromBody] CarritoCompra carrito_compra)
        {
            try
            {
                _logger.LogInformation("Agregando producto al carrito de compras");
                var id = await _carritoCompraBW.AgregarProductoCarrito(carrito_compra);
                return CreatedAtAction(nameof(GetProductoCarritoByIdAsync), new { id = id }, carrito_compra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetProductosCarritoByIdUsuarioAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Obteniendo carrito de compras de un usuario");
                return Ok(await _carritoCompraBW.ObtenerProductosCarritoPorUsuario(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoCarritoByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Obteniendo info de producto de carrito de un usuario");
                return Ok(await _carritoCompraBW.ObtenerProductoCarritoPorId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoCarritoByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Borrando un producto del carrito del usuario");
                return Ok(await _carritoCompraBW.BorrarProductoCarritoPorId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Compra/{id}")]
        public async Task<IActionResult> DeleteProductoCarritoByUsuarioAsync( Guid id)
        {
            try
            {
                _logger.LogInformation("Realizando compra");
                return Ok(await _carritoCompraBW.BorrarProductosCarritoPorUsuario(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("TodosCarritos")]
        public async Task<IActionResult> GetProductoTodosCarritoAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo carrito de compras");
                return Ok(await _carritoCompraBW.ObtenerCarritosCompra());
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
