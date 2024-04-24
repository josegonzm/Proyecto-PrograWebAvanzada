using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class VentasBW : IVentasBW
    {
        private IVentasDA _ventasDA;

        public VentasBW(IVentasDA ventasDA)
        {
            _ventasDA = ventasDA;
        }

        public Task<IEnumerable<Ventas>> ObtenerTodasVentas()
        {
            return _ventasDA.ObtenerTodasVentas();
        }

        public Task<Ventas> ObtenerVentasPorId(Guid id)
        {
            return _ventasDA.ObtenerVentasPorId(id);
        }
    }
}
