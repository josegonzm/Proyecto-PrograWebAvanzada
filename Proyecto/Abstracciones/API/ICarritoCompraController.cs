using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.API
{
    public interface ICarritoCompraController
    {
        //Hace un post de un producto al carrito
        [HttpPost]
        Task<IActionResult> PostProductoCarritoAsync([FromBody] CarritoCompra carrito_compra);

        //Obtiene todos los productos del carrito de un usuario en especifico
        [HttpGet]
        Task<IActionResult> GetProductosCarritoByIdUsuarioAsync(Guid id);

        //Se hace con get by id de un producto en el carrito
        [HttpGet]
        Task<IActionResult> GetProductoCarritoByIdAsync(Guid id);

        //Borra todos los productos del carrito. Se hace para simular compra
        [HttpDelete]
        Task<IActionResult> DeleteProductoCarritoByIdAsync([FromQuery]Guid id);

        //Borra un producto del carrito por id. Esto se hace de forma general
        [HttpDelete]
        Task<IActionResult> DeleteProductoCarritoByUsuarioAsync(Guid id);
    }
}
