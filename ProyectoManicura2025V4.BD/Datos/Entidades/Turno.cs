using ProyectoManicura2025V4.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.BD.Datos.Entidades
{
   public class Turno : Entitybase
   {
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdServicio { get; set; }
        public ServicioE Servicio { get; set; }
        public string NombreServicio { get; set; }
        public DateTime FechaTurno { get; set; }
       public EstadoTurno Estado { get; set; }
   }
}
