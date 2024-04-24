using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.API
{
    public interface IVentasController
    {
        [HttpGet]
        Task<IActionResult> GetAsync();
        [HttpGet]
        Task<IActionResult> GetByIdAsync(Guid id);
    }
}
