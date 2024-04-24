using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface IVentasBW
    {
        Task<IEnumerable<Ventas>> ObtenerTodasVentas();
        Task<Ventas> ObtenerVentasPorId(Guid id);
    }
}
