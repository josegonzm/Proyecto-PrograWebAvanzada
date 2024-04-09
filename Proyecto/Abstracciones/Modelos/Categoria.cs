using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Categoria
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "El nombre  no puede ser menor a 5 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "La descripción no puede ser menor a 3 y tiene un maximo de 300 caracteres disponibles", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public string Imagen { get; set; }
    }
}
