﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Interfaz.Data;
using Newtonsoft.Json;

namespace Interfaz.Pages.Usuarios
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
      public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7093/API/Usuario/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(resultado);


            if (usuario == null)
            {
                return NotFound();
            }
            else 
            {
                Usuario = usuario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7093/API/Usuario/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");

        }
    }
}
