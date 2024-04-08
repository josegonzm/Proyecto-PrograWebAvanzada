using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abstracciones.Modelos;
using Interfaz.Data;

namespace Interfaz.Pages.Productos
{
    public class CreateModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producto Producto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            string endpoint = "https://localhost:7093/API/Producto";
            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync<Producto>(endpoint, Producto);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
