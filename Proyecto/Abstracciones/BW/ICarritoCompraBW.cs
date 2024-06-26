﻿using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface ICarritoCompraBW
    {
        Task<Guid> AgregarProductoCarrito(CarritoCompra carrito_compra);
        Task<IEnumerable<CarritoCompra>> ObtenerProductosCarritoPorUsuario(Guid id);
        Task<IEnumerable<Modelos.CarritoCompra>> ObtenerCarritosCompra();
        Task<CarritoCompra> ObtenerProductoCarritoPorId(Guid id);
        Task<Guid> BorrarProductoCarritoPorId(Guid id);
        Task<IEnumerable<CarritoCompra>> BorrarProductosCarritoPorUsuario(Guid id);
    }
}
