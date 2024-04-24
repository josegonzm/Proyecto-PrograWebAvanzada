using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;

namespace Interfaz.Data
{
    public class InterfazContext : DbContext
    {
        public InterfazContext (DbContextOptions<InterfazContext> options)
            : base(options)
        {
        }

        public DbSet<Abstracciones.Modelos.Proveedor> Proveedor { get; set; } = default!;

        public DbSet<Abstracciones.Modelos.Producto> Producto { get; set; } = default!;

        public DbSet<Abstracciones.Modelos.Categoria> Categoria { get; set; } = default!;

        public DbSet<Abstracciones.Modelos.Usuario> Usuario { get; set; } = default!;

        public DbSet<Abstracciones.Modelos.CarritoCompra> CarritoCompra { get; set; } = default!;

        public DbSet<Abstracciones.Modelos.Ventas> Ventas { get; set; } = default!;
    }
}
