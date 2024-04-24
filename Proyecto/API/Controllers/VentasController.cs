using Abstracciones.API;
using Abstracciones.BW;
using BW;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class VentasController :  Controller, IVentasController
    {
        private IVentasBW _ventasBW;
        private readonly ILogger<VentasController> _logger;

        public VentasController(IVentasBW ventasBW, ILogger<VentasController> logger)
        {
            _ventasBW = ventasBW;
            _logger = logger;
        }

        [HttpGet]
        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                _logger.LogInformation("Consultando ventas");
                return Ok(await _ventasBW.ObtenerTodasVentas());
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
                _logger.LogInformation("Consultando venta");
                return Ok(await _ventasBW.ObtenerVentasPorId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
