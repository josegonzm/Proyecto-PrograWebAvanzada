using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ProveedorController: Controller, IProveedorController
    {
        private IProveedorBW _proveedorBW;
        private readonly ILogger<ProveedorController> _logger;

        public ProveedorController(IProveedorBW proveedorBW, ILogger<ProveedorController> logger)
        {
            _logger = logger;
            _proveedorBW = proveedorBW;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _proveedorBW.ObtenerTodosProveedores());
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
                return Ok(await _proveedorBW.ObtenerProveedorPorId(id));
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
                return NotFound(await _proveedorBW.EliminarProveedor(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Proveedor proveedor)
        {
            try
            {
                _logger.LogInformation("Agregando persona");
                var id = await _proveedorBW.AgregarProveedor(proveedor);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Proveedor proveedor)
        {
            try
            {
                _logger.LogInformation("Editando persona");
                //var validacion = await _proveedorBW.ObtenerProveedorPorId(id);
                //if ( validacion == null)
                //    return NotFound();

                return Ok(await _proveedorBW.ModificarProveedor(id, proveedor));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
