using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface ICategoriaBW
    {

        Task<IEnumerable<Categoria>> ObtenerTodasCategorias();
        Task<Categoria> ObtenerCategoriaPorId(Guid id);
        Task<Guid> EliminarCategoria(Guid id);
        Task<Guid> ModificarCategoria(Guid id, Categoria categoria);
        Task<Guid> AgregarCategoria(Categoria categoria);
    }
}
