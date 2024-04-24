using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Ventas
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid Id_Usuario { get; set; }
        [Required]
        public Guid Id_Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
