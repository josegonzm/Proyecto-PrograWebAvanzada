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
    public class ProveedorBW : IProveedorBW
    {
        private IProveedorDA _proveedorDA;

        public ProveedorBW(IProveedorDA proveedor)
        {
            _proveedorDA = proveedor;
        }

        public async Task<Guid> AgregarProveedor(Proveedor proveedor)
        {
            return await _proveedorDA.AgregarProveedor(proveedor);
        }

        public async Task<Guid> EliminarProveedor(Guid id)
        {
            return await _proveedorDA.EliminarProveedor(id);
        }

        public async Task<Guid> ModificarProveedor(Guid id, Proveedor proveedor)
        {
            return await _proveedorDA.ModificarProveedor(id, proveedor);
        }

        public async Task<Proveedor> ObtenerProveedorPorId(Guid id)
        {
            return await _proveedorDA.ObtenerProveedorPorId(id);
        }

        public async Task<IEnumerable<Proveedor>> ObtenerTodosProveedores()
        {
            return await _proveedorDA.ObtenerTodosProveedores();
        }
    }
}
