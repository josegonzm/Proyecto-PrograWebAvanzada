﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Interfaz.Data;

namespace Interfaz.Pages.VistaProductos
{
    public class DeleteModel : PageModel
    {
        private readonly Interfaz.Data.InterfazContext _context;

        public DeleteModel(Interfaz.Data.InterfazContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
            else 
            {
                Producto = producto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }
            var producto = await _context.Producto.FindAsync(id);

            if (producto != null)
            {
                Producto = producto;
                _context.Producto.Remove(Producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
