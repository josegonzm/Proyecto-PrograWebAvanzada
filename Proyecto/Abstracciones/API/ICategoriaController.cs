﻿using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.API
{
    public interface ICategoriaController
    {
        [HttpGet]
        Task<IActionResult> GetAsync();
        [HttpGet]
        Task<IActionResult> GetByIdAsync(Guid id);
        [HttpDelete]
        Task<IActionResult> DeleteAsync([FromQuery] Guid id);
        [HttpPost]
        Task<IActionResult> PostAsync([FromBody] Categoria categoria);
        [HttpPut]
        Task<IActionResult> PutAsync([FromQuery] Guid id, [FromBody] Categoria categoria);
    }
}
