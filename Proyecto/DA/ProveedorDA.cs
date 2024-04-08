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
    public class ProveedorDA : IProveedorDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ProveedorDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarProveedor(Proveedor proveedor)
        {
            string sql = @"[AgregarProveedor]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = proveedor.Nombre, Contacto = proveedor.Contacto, Pais = proveedor.Pais, Notas_Adicionales = proveedor.Notas_Adicionales });
            return (Guid)Consulta;
        }

        public async Task<Guid> EliminarProveedor(Guid id)
        {
            string sql = @"[EliminarProveedor]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new {Id = id});
            return id;
        }

        public async Task<Guid> ModificarProveedor(Guid id, Proveedor proveedor)
        {
            string sql = @"[ModificarProveedor]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql,new {Id = id, Nombre = proveedor.Nombre, Contacto = proveedor.Contacto, Pais = proveedor.Pais, Notas_Adicionales = proveedor.Notas_Adicionales});
            return id;
        }

        public async Task<Proveedor> ObtenerProveedorPorId(Guid id)
        {
            string sql = @"[ObtenerProveedorPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Proveedor>(sql, new {Id = id});
            return ConvertirProveedorDBAModelo(Consulta.First());
        }

        public async Task<IEnumerable<Proveedor>> ObtenerTodosProveedores()
        {
            string sql = @"[ObtenerTodosProveedores]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Proveedor>(sql);
            return ConvertirListaProveedorDBAModelo(Consulta.ToList());
        }

        private IEnumerable<Abstracciones.Modelos.Proveedor> ConvertirListaProveedorDBAModelo(IEnumerable<Abstracciones.Entities.Proveedor> Proveedor)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Proveedor, Abstracciones.Modelos.Proveedor>(Proveedor);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Proveedor ConvertirProveedorDBAModelo(Abstracciones.Entities.Proveedor Proveedor)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Proveedor, Abstracciones.Modelos.Proveedor>(Proveedor);
            return resultadoConversion;
        }
    }
}
