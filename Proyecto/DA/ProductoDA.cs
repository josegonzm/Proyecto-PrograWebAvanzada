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
    public class ProductoDA : IProductoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ProductoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarProducto(Producto producto)
        {
            string sql = @"[AgregarProducto]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = producto.Nombre, Descripcion = producto.Descripcion, Marca = producto.Marca, Precio = producto.Precio, Estado = producto.Estado, Imagen = producto.Imagen, Id_Categoria = producto.Id_Categoria, Id_Proveedor = producto.Id_Proveedor });
            return (Guid)Consulta;
        }
        public async Task<Guid> EliminarProducto(Guid id)
        {
            string sql = @"[EliminarProducto]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return id;
        }
        public async Task<Guid> ModificarProducto(Guid id, Abstracciones.Modelos.Producto producto)
        {
            string sql = @"[ModificarProducto]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id, Nombre = producto.Nombre, Descripcion = producto.Descripcion, Marca = producto.Marca, Precio = producto.Precio, Estado = producto.Estado, Imagen = producto.Imagen, Id_Categoria = producto.Id_Categoria, Id_Proveedor = producto.Id_Proveedor});
            return id;
        }
        public async Task<Abstracciones.Modelos.Producto> ObtenerProductoPorId(Guid id)
        {
            string sql = @"[ObtenerProductoPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Producto>(sql, new { Id = id });
            return ConvertirProductoDBAModelo(Consulta.First());
        }

        public async Task<IEnumerable<Abstracciones.Modelos.Producto>> ObtenerTodosProductos()
        {
            string sql = @"[ObtenerTodosProductos]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Producto>(sql);
            return ConvertirListaProductoDBAModelo(Consulta.ToList());
        }

        private IEnumerable<Abstracciones.Modelos.Producto> ConvertirListaProductoDBAModelo(IEnumerable<Abstracciones.Entities.Producto> Producto)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Producto, Abstracciones.Modelos.Producto>(Producto);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Producto ConvertirProductoDBAModelo(Abstracciones.Entities.Producto Producto)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Producto, Abstracciones.Modelos.Producto>(Producto);
            return resultadoConversion;
        }
    }
}
