using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Usuario
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "El nombre  no puede ser menor a 3 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 3)]
        public string NombreUsuario { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]

        public string Correo { get; set; }
    }
}
