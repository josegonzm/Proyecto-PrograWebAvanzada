using Abstracciones.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class CarritoCompra
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid Id_Usuario { get; set; }
        [Required]
        public Guid Id_Producto { get; set; }
        public string? NombreProducto { get; set; }
        public string? ImagenProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? PrecioProducto { get; set; }

        [Required]
        [ValidarCantidad]
        public int Cantidad { get; set; }
    }
}
