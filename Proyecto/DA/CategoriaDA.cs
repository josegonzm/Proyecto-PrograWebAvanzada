using Abstracciones.DA;
using Abstracciones.Modelos;
using Dapper;
using Helpers;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CategoriaDA: ICategoriaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;
        public CategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarCategoria(Categoria categoria)
        {
            string sql = @"[AgregarCategoria]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = categoria.Nombre, Descripcion = categoria.Descripcion, Imagen = categoria.Imagen });
            return (Guid)Consulta;
        }
        public async Task<Guid> EliminarCategoria(Guid id)
        {
            string sql = @"[EliminarCategoria]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return id;
        }
        public async Task<Guid> ModificarCategoria(Guid id, Abstracciones.Modelos.Categoria categoria)
        {
            string sql = @"[ModificarCategoria]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id, Nombre = categoria.Nombre, Descripcion = categoria.Descripcion, Imagen = categoria.Imagen });
            return id;
        }
        public async Task<Abstracciones.Modelos.Categoria> ObtenerCategoriaPorId(Guid id)
        {
            string sql = @"[ObtenerCategoriaPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Categoria>(sql, new { Id = id });
            return ConvertirUsuarioDBAModelo(Consulta.First());
        }

        public async Task<IEnumerable<Abstracciones.Modelos.Categoria>> ObtenerTodasCategorias()
        {
            string sql = @"[ObtenerTodasCategoria]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Categoria>(sql);
            return ConvertirListaUsuarioDBAModelo(Consulta.ToList());
        }

        private IEnumerable<Abstracciones.Modelos.Categoria> ConvertirListaUsuarioDBAModelo(IEnumerable<Abstracciones.Entities.Categoria> Categoria)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Categoria, Abstracciones.Modelos.Categoria>(Categoria);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Categoria ConvertirUsuarioDBAModelo(Abstracciones.Entities.Categoria Categoria)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Categoria, Abstracciones.Modelos.Categoria>(Categoria);
            return resultadoConversion;
        }
    }
}
