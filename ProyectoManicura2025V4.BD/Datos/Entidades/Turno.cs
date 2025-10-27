using ProyectoManicura2025V4.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.BD.Datos.Entidades
{
   public class turno : Entitybase
   {
        public string NombreCliente { get; set; }
        public int ServicioId { get; set; }
        public ServicioE Servicio { get; set; }
        public DateTime FechaHora { get; set; }

        public EstadoTurno Estado { get; set; }
   }
}
