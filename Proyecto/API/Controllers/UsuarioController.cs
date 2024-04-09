using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using BW;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class UsuarioController : Controller, IUsuarioController
    {
        
        private IUsuarioBW _usuarioBW;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioBW usuarioBW, ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _usuarioBW = usuarioBW;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _usuarioBW.ObtenerTodosUsuarios());
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
                _logger.LogInformation("Consultando usuarios");
                return Ok(await _usuarioBW.ObtenerUsuarioPorId(id));
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
                _logger.LogInformation("Eliminando usuario");
                return Ok(await _usuarioBW.EliminarUsuario(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Agregando persona");
                var id = await _usuarioBW.AgregarUsuario(usuario);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Editando usuario");
                return Ok(await _usuarioBW.ModificarUsuario(id, usuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
