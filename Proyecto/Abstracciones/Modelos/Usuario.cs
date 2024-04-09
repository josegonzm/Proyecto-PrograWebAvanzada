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
        [StringLength(40, ErrorMessage = "El nombre  no puede ser menor a 5 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "El primer apellido  no puede ser menor a 5 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 5)]
        public string Primer_Apellido { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "El segundo apellido  no puede ser menor a 5 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 5)]
        public string Segundo_Apellido { get; set; }

        [Required]
        [EmailAddress]

        public string Correo { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [Required]

        public Guid Id_Rol {  get; set; }
    }
}
