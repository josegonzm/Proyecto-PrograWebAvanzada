using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface ICarritoCompraDA
    {
        Task<Guid> AgregarProductoCarrito(CarritoCompra carrito_compra);
        Task<IEnumerable<CarritoCompra>> ObtenerProductosCarritoPorUsuario(Guid id);
        Task<CarritoCompra> ObtenerProductoCarritoPorId(Guid id);
        Task<Guid> BorrarProductoCarritoPorId(Guid id);
        //Task<IEnumerable<Carrito_Compra>> BorrarProductosCarritoPorUsuario(Guid id);
    }
}
