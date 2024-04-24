using Abstracciones.DA;
using Abstracciones.Entities;
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
    public class UsuarioDA: IUsuarioDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;
        public UsuarioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarUsuario(Abstracciones.Modelos.Usuario usuario)
        {
            string sql = @"[AgregarUsuario]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { NombreUsuario = usuario.NombreUsuario, PasswordHash = usuario.PasswordHash, CorreoElectronico = usuario.Correo });
            return (Guid)Consulta;
        }
        public async Task<IEnumerable<Abstracciones.Modelos.Usuario>> ObtenerTodosUsuarios()
        {
            ;           string sql = @"[ObtenerTodasUsuario]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Usuario>(sql);
            return ConvertirListaUsuarioDBAModelo(Consulta.ToList());
        }

        public async Task<Abstracciones.Modelos.Usuario> ObtenerUsuarioPorId(Guid id)
        {
            string sql = @"[ObtenerUsuarioPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Usuario>(sql, new { Id = id });
            return ConvertirUsuarioDBAModelo(Consulta.First());
        }

        private IEnumerable<Abstracciones.Modelos.Usuario> ConvertirListaUsuarioDBAModelo(IEnumerable<Abstracciones.Entities.Usuario> Usuario)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Usuario, Abstracciones.Modelos.Usuario>(Usuario);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Usuario ConvertirUsuarioDBAModelo(Abstracciones.Entities.Usuario Usuario)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Usuario, Abstracciones.Modelos.Usuario>(Usuario);
            return resultadoConversion;
        }
    }
}
