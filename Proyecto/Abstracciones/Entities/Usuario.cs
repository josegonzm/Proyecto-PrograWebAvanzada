using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Usuario
    {
        
        public Guid Id { get; set; }

        
        public string Nombre { get; set; }

        public string Primer_Apellido { get; set; }

       
        public string Segundo_Apellido { get; set; }

     

        public string Correo { get; set; }

        
        public string Telefono { get; set; }

        public string ContrasenaHash { get; set; }


        public Guid Id_Rol { get; set; }
    }
}
