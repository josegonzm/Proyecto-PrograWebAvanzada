using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface IProductoBW
    {
        Task<IEnumerable<Producto>> ObtenerTodosProductos();
        Task<Producto> ObtenerProductoPorId(Guid id);
        Task<Guid> EliminarProducto(Guid id);
        Task<Guid> ModificarProducto(Guid id, Producto producto /*, Guid idCategoria, Guid idProveedor*/);
        Task<Guid> AgregarProducto(Producto producto /*, Guid idCategoria, Guid idProveedor*/);
    }
}
