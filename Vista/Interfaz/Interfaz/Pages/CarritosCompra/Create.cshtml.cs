using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abstracciones.Modelos;
using Interfaz.Data;

namespace Interfaz.Pages.CarritosCompra
{
    public class CreateModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public CreateModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarritoCompra CarritoCompra { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CarritoCompra == null || CarritoCompra == null)
            {
                return Page();
            }

            _context.CarritoCompra.Add(CarritoCompra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
