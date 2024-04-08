using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Proveedor
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "El nombre tiene no puede ser menor a 5 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required]
        [Phone]
        public string Contacto { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "El nombre tiene no puede ser menor a 5 y tiene un maximo de 40 caracteres disponibles", MinimumLength = 5)]
        public string Pais { get; set; }
        public string? Notas_Adicionales { get; set; }
    }
}
