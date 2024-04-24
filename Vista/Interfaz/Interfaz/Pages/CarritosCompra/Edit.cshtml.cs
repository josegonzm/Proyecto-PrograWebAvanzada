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

namespace Interfaz.Pages.CarritosCompra
{
    public class EditModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public EditModel(Interfaz.Data.InterfazContext context)
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

            var carritocompra =  await _context.CarritoCompra.FirstOrDefaultAsync(m => m.Id == id);
            if (carritocompra == null)
            {
                return NotFound();
            }
            CarritoCompra = carritocompra;
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

            _context.Attach(CarritoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoCompraExists(CarritoCompra.Id))
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

        private bool CarritoCompraExists(Guid id)
        {
          return (_context.CarritoCompra?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
