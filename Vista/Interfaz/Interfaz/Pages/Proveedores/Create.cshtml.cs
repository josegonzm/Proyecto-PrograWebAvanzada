﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abstracciones.Modelos;
using Interfaz.Data;

namespace Interfaz.Pages.Proveedores
{
    public class CreateModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            string endpoint = "https://localhost:7093/API/Proveedor";
            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync<Proveedor>(endpoint, Proveedor);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
