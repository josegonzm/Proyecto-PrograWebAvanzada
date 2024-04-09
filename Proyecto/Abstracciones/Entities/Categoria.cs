﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }   

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }
    }

}