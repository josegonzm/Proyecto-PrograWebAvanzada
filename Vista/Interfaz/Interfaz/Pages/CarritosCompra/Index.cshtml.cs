using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Interfaz.Data;

namespace Interfaz.Pages.CarritosCompra
{
    public class IndexModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public IndexModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

        public IList<CarritoCompra> CarritoCompra { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CarritoCompra != null)
            {
                CarritoCompra = await _context.CarritoCompra.ToListAsync();
            }
        }
    }
}
