﻿using System;
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
    }
}
