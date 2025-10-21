using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.BD.Datos.Entidades
{
    public class Cliente : Entitybase
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El nombre no puede tener más de 20 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(20, ErrorMessage = "El apellido no puede tener más de 20 caracteres")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El numero es obligatorio")]
        [MaxLength(15, ErrorMessage = "El telefono no puede tener más de 15 caracteres")]
        public required string Telefono { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
