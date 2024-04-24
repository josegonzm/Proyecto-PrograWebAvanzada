using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Ventas
    {
        public Guid Id { get; set; }
        public Guid Id_Usuario { get; set; }
        public Guid Id_Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
