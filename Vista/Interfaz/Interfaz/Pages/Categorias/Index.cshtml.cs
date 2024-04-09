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

namespace Interfaz.Pages.Categorias
{
    public class IndexModel : PageModel
    {

        public IList<Categoria> Categoria { get;set; } = default!;

        public async Task OnGetAsync()
        {
            string endpoint = "https://localhost:7093/API/Categoria";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            Categoria = JsonConvert.DeserializeObject<List<Categoria>>(resultado);
        }
    }
}
