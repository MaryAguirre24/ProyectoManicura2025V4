using ProyectoManicura2025V4.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.Shared.DTO
{
    public class TurnoCrearDTO
    {
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaTurno { get; set; }
        public EstadoTurno Estado { get; set; }
    }
}
