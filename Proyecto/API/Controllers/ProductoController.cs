using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using BW;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ProductoController : Controller, IProductoController
    {
        private IProductoBW _productoBW;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(IProductoBW productoBW, ILogger<ProductoController> logger)
        {
            _logger = logger;
            _productoBW = productoBW;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _productoBW.ObtenerTodosProductos());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Consultando personas");
                return Ok(await _productoBW.ObtenerProductoPorId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Eliminando persona");
                return Ok(await _productoBW.EliminarProducto(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Producto producto)
        {
            try
            {
                _logger.LogInformation("Agregando persona");
                var id = await _productoBW.AgregarProducto(producto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Producto producto)
        {
            try
            {
                _logger.LogInformation("Editando persona");
                return Ok(await _productoBW.ModificarProducto(id, producto));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("ObtenerId/{id}")]
        public async Task<IActionResult> GetIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Consultando personas");
                return Ok(await _productoBW.ObtenerIdProducto(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
