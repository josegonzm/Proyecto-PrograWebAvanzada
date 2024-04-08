using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Interfaz.Data;
using Newtonsoft.Json;

namespace Interfaz.Pages.Productos
{
    public class EditModel : PageModel
    {

        [BindProperty]
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
            Producto = producto;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await ProductoExistsAsync(Producto.Id))
            {
                string endpoint = "https://localhost:7093/API/Producto/{0}";
                var cliente = new HttpClient();
                var respuesta = await cliente.PutAsJsonAsync<Producto>(string.Format(endpoint, Producto.Id), Producto);
                respuesta.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }

        private async Task<bool> ProductoExistsAsync(Guid id)
        {
            string endpoint = "https://localhost:7093/API/Producto/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<Producto>(resultado);
            if (producto != null)
                return true;
            return false;
        }
    }
}
