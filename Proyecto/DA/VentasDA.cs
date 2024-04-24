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
    public class VentasDA : IVentasDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public VentasDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<Ventas>> ObtenerTodasVentas()
        {
            string sql = @"[ObtenerTodasVentas]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Ventas>(sql);
            return ConvertirListaVentasDBAModelo(Consulta.ToList());
        }

        public async Task<Ventas> ObtenerVentasPorId(Guid id)
        {
            string sql = @"[ObtenerTodasVentasPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Ventas>(sql, new { Id = id });
            return ConvertirVentasDBAModelo(Consulta.First());
        }

        private IEnumerable<Abstracciones.Modelos.Ventas> ConvertirListaVentasDBAModelo(IEnumerable<Abstracciones.Entities.Ventas> Ventas)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Ventas, Abstracciones.Modelos.Ventas>(Ventas);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Ventas ConvertirVentasDBAModelo(Abstracciones.Entities.Ventas Ventas)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Ventas, Abstracciones.Modelos.Ventas>(Ventas);
            return resultadoConversion;
        }
    }
}
