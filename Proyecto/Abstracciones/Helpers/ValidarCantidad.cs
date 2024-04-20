using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Helpers
{
    public class ValidarCantidad : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CarritoCompra carrito_compra = (CarritoCompra)validationContext.ObjectInstance;
            if (carrito_compra.Cantidad == 0)
            {
                return new ValidationResult("Tiene que añadir minimo un producto al carrito de compras");
            }
            return ValidationResult.Success;
        }
    }
}
