using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Proveedor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Pais { get; set; }
        public string? Notas_Adicionales { get; set; }
    }
}
