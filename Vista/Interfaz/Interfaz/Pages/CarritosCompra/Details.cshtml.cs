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
    public class DetailsModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public DetailsModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

      public CarritoCompra CarritoCompra { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.CarritoCompra == null)
            {
                return NotFound();
            }

            var carritocompra = await _context.CarritoCompra.FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
