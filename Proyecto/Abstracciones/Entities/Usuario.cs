using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Usuario
    {

        public Guid Id { get; set; }

        public string NombreUsuario { get; set; }


        public string PasswordHash { get; set; }

        public string Correo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCrea { get; set; }
        public Guid UsuarioModifica { get; set; }

    }
}
