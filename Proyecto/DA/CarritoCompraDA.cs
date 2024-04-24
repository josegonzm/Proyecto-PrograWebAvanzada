using Abstracciones.DA;
using Abstracciones.Modelos;
using Dapper;
using Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class CarritoCompraDA : ICarritoCompraDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public CarritoCompraDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarProductoCarrito(CarritoCompra carrito_compra)
        {
            string sql = @"[AgregarProductoCarrito]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new
            {
                IdUsuario = carrito_compra.Id_Usuario,
                IdProducto = carrito_compra.Id_Producto,
                Cantidad = carrito_compra.Cantidad
            });
            return (Guid)Consulta;
        }

        public async Task<Guid> BorrarProductoCarritoPorId(Guid id)
        {
            string sql = @"[BorrarProductoCarrito]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new {Id = id});
            return id;
        }

        public async Task<IEnumerable<CarritoCompra>> ObtenerProductosCarritoPorUsuario(Guid id) //Puede que sea necesario poner un objeto tipo carrito de compra
        {
            string sql = @"[ObtenerProductosCarritoPorUsuario]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.CarritoCompra>(sql, new {IdUsuario = id});
            return ConvertirListaCarrito_CompraDBAModelo(Consulta.ToList());
        }

        public async Task<CarritoCompra> ObtenerProductoCarritoPorId(Guid id)
        {
            string sql = @"[ObtenerProductoCarritoPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.CarritoCompra>(sql, new {Id = id});
            return ConvertirCarrito_CompraDBAModelo(Consulta.First());
        }

        public async Task<IEnumerable<CarritoCompra>> ObtenerCarritosCompra()
        {
            string sql = @"[ObtenerTodosCarritos]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.CarritoCompra>(sql);
            return ConvertirListaCarrito_CompraDBAModelo(Consulta.ToList());
        }

        

        //Revisar codigo

        public async Task<IEnumerable<CarritoCompra>> BorrarProductosCarritoPorUsuario(Guid id)
        {
            string sql = @"[BorrarProductosCarritoPorUsuario]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.CarritoCompra>(sql, new { IdUsuario = id });
            return ConvertirListaCarrito_CompraDBAModelo(Consulta.ToList());
        }

        private IEnumerable<Abstracciones.Modelos.CarritoCompra> ConvertirListaCarrito_CompraDBAModelo(IEnumerable<Abstracciones.Entities.CarritoCompra> Carrito_Compra)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.CarritoCompra, Abstracciones.Modelos.CarritoCompra>(Carrito_Compra);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.CarritoCompra ConvertirCarrito_CompraDBAModelo(Abstracciones.Entities.CarritoCompra Carrito_Compra)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.CarritoCompra, Abstracciones.Modelos.CarritoCompra>(Carrito_Compra);
            return resultadoConversion;
        }
    }
}
