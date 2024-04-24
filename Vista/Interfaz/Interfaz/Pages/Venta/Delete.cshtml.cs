using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Interfaz.Data;

namespace Interfaz.Pages.Venta
{
    public class DeleteModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public DeleteModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ventas Ventas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.FirstOrDefaultAsync(m => m.Id == id);

            if (ventas == null)
            {
                return NotFound();
            }
            else 
            {
                Ventas = ventas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }
            var ventas = await _context.Ventas.FindAsync(id);

            if (ventas != null)
            {
                Ventas = ventas;
                _context.Ventas.Remove(Ventas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
