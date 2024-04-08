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

namespace Interfaz.Pages.Productos
{
    public class DetailsModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public DetailsModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

      public Producto Producto { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7093/API/Producto/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<Producto>(resultado);

            if (producto == null)
            {
                return NotFound();
            }
            else 
            {
                Producto = producto;
            }
            return Page();
        }
    }
}
