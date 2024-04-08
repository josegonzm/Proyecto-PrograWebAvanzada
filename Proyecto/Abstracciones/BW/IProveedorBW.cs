using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface IProveedorBW
    {
        Task<IEnumerable<Proveedor>> ObtenerTodosProveedores();
        Task<Proveedor> ObtenerProveedorPorId(Guid id);
        Task<Guid> EliminarProveedor(Guid id);
        Task<Guid> ModificarProveedor(Guid id, Proveedor proveedor);
        Task<Guid> AgregarProveedor(Proveedor proveedor);
    }
}
