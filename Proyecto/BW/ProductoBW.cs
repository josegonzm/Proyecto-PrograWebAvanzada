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
    public class ProductoBW : IProductoBW
    {
        private IProductoDA _productoDA;
        public ProductoBW(IProductoDA productoDA)
        {
            _productoDA = productoDA;
        }

        public async Task<Guid> AgregarProducto(Producto producto)
        {
            return await _productoDA.AgregarProducto(producto);
        }

        public async Task<Guid> EliminarProducto(Guid id)
        {
            return await _productoDA.EliminarProducto(id);
        }

        public async Task<Guid> ModificarProducto(Guid id, Producto producto)
        {
            return await _productoDA.ModificarProducto(id, producto);
        }

        public async Task<Producto> ObtenerIdProducto(Guid id)
        {
            return await _productoDA.ObtenerIdProducto(id);
        }

        public async Task<Producto> ObtenerProductoPorId(Guid id)
        {
            return await _productoDA.ObtenerProductoPorId(id);
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosProductos()
        {
            return await _productoDA.ObtenerTodosProductos();
        }
    }
}
