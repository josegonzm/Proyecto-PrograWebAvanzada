using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Producto
    {
        public Guid Id { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public char Estado { get; set; }
        public string Imagen { get; set; }
        public Guid Id_Categoria { get; set; }
        public Guid Id_Proveedor { get; set; }
    }
}
