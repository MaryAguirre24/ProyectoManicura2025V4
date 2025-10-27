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
    public class TurnoRepositorio : Repositorio<turno>, IRepositorio<turno>,ITurnoRepositorio
    {
        private readonly AppDbContext context;

        public TurnoRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
       
        public async Task<List<TurnoListadoDTO>> ObtenerListaTurnosDTO()
        {
            var listaTurnosDTO = await context.Turnos
                .Include(t => t.Servicio)
                .Select(t => new TurnoListadoDTO
                {
                    Id = t.Id,
                    NombreCliente = t.NombreCliente,
                    ServicioId = t.ServicioId,
                    FechaHora = t.FechaHora,
                    Estado = t.Estado
                })
                .ToListAsync();
            return listaTurnosDTO;
        }
        public async Task<bool> ExisteTurnoEnFechaHora(int ServicoId ,DateTime fechaHora)
        {
            var fechacompleta = await context.Turnos
                .AnyAsync(t => t.ServicioId == ServicoId && t.FechaHora == fechaHora);
            return await context.Turnos.AnyAsync(t => t.FechaHora == fechaHora);
        }








    }

    
}
