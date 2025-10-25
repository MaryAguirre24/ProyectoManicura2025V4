using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;
using ProyectoManicura2025V4.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.Repositorio.Repositorios
{
    public class TurnoRepositorio : Repositorio<Turno>, IRepositorio<Turno>,ITurnoRepositorio
    {
        private readonly AppDbContext context;

        public TurnoRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
       
        public async Task<List<TurnoListadoDTO>> ObtenerListaTurnosDTO()
        {
            var listaTurnosDTO = await context.Turnos
                .Include(t => t.Cliente)
                .Include(t => t.Servicio)
                .Select(t => new TurnoListadoDTO
                {
                    Id = t.Id,
                    FechaTurno = t.FechaTurno,
                    Estado = t.Estado,
                    NombreCliente = t.Cliente.NombreCliente,
                    NombreServicio = t.Servicio.NombreServicio
                })
                .ToListAsync();
            return listaTurnosDTO;
        }






    }

    
}
