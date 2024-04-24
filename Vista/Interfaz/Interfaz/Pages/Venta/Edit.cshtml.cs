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

namespace Interfaz.Pages.Venta
{
    public class EditModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public EditModel(Interfaz.Data.InterfazContext context)
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

            var ventas =  await _context.Ventas.FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }
            Ventas = ventas;
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

            _context.Attach(Ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(Ventas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VentasExists(Guid id)
        {
          return (_context.Ventas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
