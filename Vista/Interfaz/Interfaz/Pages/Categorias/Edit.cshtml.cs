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

namespace Interfaz.Pages.Categorias
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Categoria Categoria { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7093/API/Categoria/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<Categoria>(resultado);

            if (categoria == null)
            {
                return NotFound();
            }
            Categoria = categoria;
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

            if (await CategoriaExistsAsync(Categoria.Id))
            {
                string endpoint = "https://localhost:7093/API/Categoria/{0}";
                var cliente = new HttpClient();
                var respuesta = await cliente.PutAsJsonAsync<Categoria>(string.Format(endpoint, Categoria.Id), Categoria);
                respuesta.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }

        private async Task<bool> CategoriaExistsAsync(Guid id)
        {
            string endpoint = "https://localhost:7093/API/Categoria/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<Categoria>(resultado);
            if (categoria != null)
                return true;
            return false;
        }
    }
}
