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

namespace Interfaz.Pages.VistaProductos
{
    public class IndexModel : PageModel
    {
      
        

        public IList<Producto> Producto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            string endpoint = "https://localhost:7093/API/Producto";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            Producto = JsonConvert.DeserializeObject<List<Producto>>(resultado);
        }
    }
}
