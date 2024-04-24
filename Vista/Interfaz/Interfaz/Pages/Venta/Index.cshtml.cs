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

namespace Interfaz.Pages.Venta
{
    public class IndexModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public IndexModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

        public IList<Ventas> Ventas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            string endpoint = "https://localhost:7093/API/Ventas";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            Ventas = JsonConvert.DeserializeObject<List<Ventas>>(resultado);
        }
    }
}
