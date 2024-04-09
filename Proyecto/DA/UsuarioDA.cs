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
    public class UsuarioDA: IUsuarioDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;
        public UsuarioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarUsuario(Usuario usuario)
        {
            string sql = @"[AgregarUsuario]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = usuario.Nombre, Primer_Apellido = usuario.Primer_Apellido, Segundo_Apellido = usuario.Segundo_Apellido, Correo = usuario.Correo, Telefono = usuario.Telefono, Id_Rol = usuario.Id_Rol});
            return (Guid)Consulta;
        }
        public async Task<Guid> EliminarUsuario(Guid id)
        {
            string sql = @"[EliminarUsuario]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return id;
        }
        public async Task<Guid> ModificarUsuario(Guid id, Abstracciones.Modelos.Usuario usuario)
        {
            string sql = @"[ModificarUsuario]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id, Nombre = usuario.Nombre, Primer_Apellido = usuario.Primer_Apellido, Segundo_Apellido = usuario.Segundo_Apellido, Correo = usuario.Correo, Telefono = usuario.Telefono, Id_Rol = usuario.Id_Rol });
            return id;
        }
        public async Task<Abstracciones.Modelos.Usuario> ObtenerUsuarioPorId(Guid id)
        {
            string sql = @"[ObtenerUsuarioPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Usuario>(sql, new { Id = id });
            return ConvertirUsuarioDBAModelo(Consulta.First());
        }

        public async Task<IEnumerable<Abstracciones.Modelos.Usuario>> ObtenerTodosUsuarios()
        {
            string sql = @"[ObtenerTodasUsuario]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Usuario>(sql);
            return ConvertirListaUsuarioDBAModelo(Consulta.ToList());
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
