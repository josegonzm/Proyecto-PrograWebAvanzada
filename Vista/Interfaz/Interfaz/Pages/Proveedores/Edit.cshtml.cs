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

namespace Interfaz.Pages.Proveedores
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Proveedor Proveedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7093/API/Proveedor/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var proveedor = JsonConvert.DeserializeObject<Proveedor>(resultado);

            if (proveedor == null)
            {
                return NotFound();
            }
            Proveedor = proveedor;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (await ProveedorExistsAsync(Proveedor.Id))
            {
                string endpoint = "https://localhost:7093/API/Proveedor/{0}";
                var cliente = new HttpClient();
                var respuesta = await cliente.PutAsJsonAsync<Proveedor>(string.Format(endpoint, Proveedor.Id), Proveedor);
                respuesta.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }

        private async Task<bool> ProveedorExistsAsync(Guid id)
        {
            string endpoint = "https://localhost:7093/API/Proveedor/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var proveedor = JsonConvert.DeserializeObject<Proveedor>(resultado);
            if (proveedor != null)
                return true;
            return false;
        }
    }
}
