using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class UsuarioBW: IUsuarioBW
    {

        private IUsuarioDA _usuarioDA;
        public UsuarioBW(IUsuarioDA usuarioDA)
        {
            _usuarioDA = usuarioDA;
        }

        public async Task<Guid> AgregarUsuario(Usuario usuario)
        {
            return await _usuarioDA.AgregarUsuario(usuario);
        }

        public async Task<Usuario> ObtenerUsuarioPorId(Guid id)
        {
            return await _usuarioDA.ObtenerUsuarioPorId(id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosUsuarios()
        {
            return await _usuarioDA.ObtenerTodosUsuarios();
        }

    }
}
