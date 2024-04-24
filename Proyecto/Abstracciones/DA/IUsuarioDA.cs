using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IUsuarioDA
    {

        Task<IEnumerable<Usuario>> ObtenerTodosUsuarios();
        Task<Usuario> ObtenerUsuarioPorId(Guid id);
        Task<Guid> AgregarUsuario(Usuario usuario);

    }
}
