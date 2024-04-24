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
    public class CarritoCompraBW : ICarritoCompraBW
    {
        ICarritoCompraDA _carritoCompraDA;

        public CarritoCompraBW(ICarritoCompraDA carritoCompraDA)
        {
            _carritoCompraDA = carritoCompraDA;
        }

        public Task<Guid> AgregarProductoCarrito(CarritoCompra carrito_compra)
        {
            return _carritoCompraDA.AgregarProductoCarrito(carrito_compra);
        }

        public Task<Guid> BorrarProductoCarritoPorId(Guid id)
        {
            return _carritoCompraDA.BorrarProductoCarritoPorId(id);
        }

        public Task<IEnumerable<CarritoCompra>> BorrarProductosCarritoPorUsuario(Guid id)
        {
            return _carritoCompraDA.BorrarProductosCarritoPorUsuario(id);
        }

        public Task<IEnumerable<CarritoCompra>> ObtenerCarritosCompra()
        {
            return _carritoCompraDA.ObtenerCarritosCompra();
        }

        public Task<CarritoCompra> ObtenerProductoCarritoPorId(Guid id)
        {
            return _carritoCompraDA.ObtenerProductoCarritoPorId(id);
        }

        public Task<IEnumerable<CarritoCompra>> ObtenerProductosCarritoPorUsuario(Guid id)
        {
            return _carritoCompraDA.ObtenerProductosCarritoPorUsuario(id);
        }
    }
}
