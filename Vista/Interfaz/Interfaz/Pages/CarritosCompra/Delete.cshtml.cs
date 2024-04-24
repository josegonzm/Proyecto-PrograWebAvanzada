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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.CarritoCompra == null)
            {
                return NotFound();
            }
            var carritocompra = await _context.CarritoCompra.FindAsync(id);

            if (carritocompra != null)
            {
                CarritoCompra = carritocompra;
                _context.CarritoCompra.Remove(CarritoCompra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
