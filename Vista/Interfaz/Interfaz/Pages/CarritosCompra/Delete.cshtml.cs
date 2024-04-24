using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Interfaz.Data;
using Newtonsoft.Json;

namespace Interfaz.Pages.CarritosCompra
{
    public class DeleteModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public DeleteModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CarritoCompra CarritoCompra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.CarritoCompra == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7093/API/CarritoCompra/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var carritocompra = JsonConvert.DeserializeObject<CarritoCompra>(resultado);

            if (carritocompra == null)
            {
                return NotFound();
            }
            else 
            {
                CarritoCompra = carritocompra;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string endpoint = "https://localhost:7093/API/CarritoCompra/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
