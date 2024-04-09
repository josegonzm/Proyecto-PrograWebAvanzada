using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CategoriaController : Controller, ICategoriaController
    {
        private ICategoriaBW _categoriaBW;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaBW categoriaBW, ILogger<CategoriaController> logger)
        {
            _logger = logger;
            _categoriaBW = categoriaBW;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _categoriaBW.ObtenerTodasCategorias());
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
                _logger.LogInformation("Consultando categoria");
                return Ok(await _categoriaBW.ObtenerCategoriaPorId(id));
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
                _logger.LogInformation("Eliminando categoria");
                return Ok(await _categoriaBW.EliminarCategoria(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Categoria categoria)
        {
            try
            {
                _logger.LogInformation("Agregando categoria");
                var id = await _categoriaBW.AgregarCategoria(categoria);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Categoria categoria)
        {
            try
            {
                _logger.LogInformation("Editando categoria");
                return Ok(await _categoriaBW.ModificarCategoria(id, categoria));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
