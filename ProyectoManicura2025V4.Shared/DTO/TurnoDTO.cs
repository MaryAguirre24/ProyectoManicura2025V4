using ProyectoManicura2025V4.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.Shared.DTO
{
    public class TurnoDTO
    {
        public string NombreCliente { get; set; }
        public int ServicioId { get; set; }
        public DateTime FechaHora { get; set; }

        public EstadoTurno Estado { get; set; }
    }
}
