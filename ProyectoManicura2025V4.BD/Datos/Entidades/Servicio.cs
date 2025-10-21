using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.BD.Datos.Entidades
{
    public class Servicio : Entitybase
    {
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength (250)]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
    }
}
