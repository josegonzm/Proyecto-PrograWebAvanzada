﻿using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IVentasDA
    {
        Task<IEnumerable<Ventas>> ObtenerTodasVentas();
        Task<Ventas> ObtenerVentasPorId(Guid id);
    }
}
