using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Producto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "El nombre no puede ser mayor a 40 caracteres y menor a 3 caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "La descripcion no puede ser mayor a 50 caracteres y menor a 3 caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "La marca no puede ser mayor a 25 caracteres y menor a 3 caracteres", MinimumLength = 3)]
        public string Marca { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public char Estado { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public Guid Id_Categoria { get; set; }
        [Required]
        public Guid Id_Proveedor { get; set; }
    }
}
