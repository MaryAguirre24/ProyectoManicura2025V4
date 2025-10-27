using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;
using ProyectoManicura2025V4.Repositorio.Repositorios;
using ProyectoManicura2025V4.Shared.DTO;
using ProyectoManicura2025V4.Shared.Enum;

namespace ProyectoManicura2025V4.Server.Controllers
{
    [ApiController]
    [Route("api/Turno")]
    public class TurnoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<turno> repositorio;

        public TurnoController(AppDbContext context,IRepositorio<turno> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<turno>>> Getturno()
        {
            var turnos = await repositorio.SelectListaTurno();
            //var listaturnos = await context.Turnos.ToListAsync();
            if (turnos == null)
            {
                return BadRequest("Error al obtener los turnos.");
            }
            if (turnos.Count == 0)
            {
                return NotFound("No se encontraron turnos.");
            }
            return Ok(turnos);
        }
        [HttpGet("listaturno")]
        public async Task<ActionResult<List<TurnoListadoDTO>>> ListaTurno()
        {
            var lista = await repositorio.SelectListaTurno();
            //var listaturnos = await context.Turnos.ToListAsync();
            if (lista == null)
            {
                return NotFound("Error al obtener los turnos.");
            }
            if (lista.Count == 0)
            {
                return Ok("Lista sin turnos.");
            }
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<turno>> GetById(int id)
        {
            var turno =  await repositorio.SelectById(id);
            //var entidad = await context.Turnos.FirstOrDefaultAsync(t => t.Id == id);
            if (turno == null)
            {
                return NotFound($"No se encontro el turno con el Id: {id}.");
            }
            return Ok(turno);

        }


        [HttpPost]
        public async Task<ActionResult<int>> PostCrear(TurnoDTO dto )
        {
            try
            {
                // Mapear el DTO a la entidad Turno
                var entidad = new turno
                {
                    NombreCliente = dto.NombreCliente,
                    ServicioId = dto.ServicioId,
                    FechaHora = dto.FechaHora,
                    Estado = dto.Estado
                };
                var existeTurno = await repositorio.ExisteTurnoEnFechaHora(entidad.ServicioId, entidad.FechaHora);
                if (existeTurno)
                {
                    return BadRequest("Ya existe un turno para el servicio y la fecha/hora especificados.");
                }
                var idInsertado = await repositorio.Insert(entidad);
                return Ok(idInsertado);
            }
            catch (Exception e)
            {
                var explicate = e.InnerException?.Message ?? e.Message;
                return BadRequest($"Error al crear el turno: {explicate}");
            }
        }


        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, turno DTO)
        {
           // if (id != DTO.Id)
           // {
            //    return BadRequest("Datos no validos.");
           // }
            //var existe = await repositorio.SelectById(id);
            //var existe = await context.Turnos.FirstOrDefaultAsync(t => t.Id == id);
           // if (existe == null)
           // {
           //     return NotFound("No se encontro el turno.");
           // }
            //context.Update(DTO);
            //await context.SaveChangesAsync();
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Error al actualizar el turno.");
            }
            return Ok($"Turno con el id: {id} actualizado correctamente");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turno = await context.Turnos.FirstOrDefaultAsync(t => t.Id == id);
            if (turno == null)
            {
                return NotFound($"No se encontro el turno con el Id: {id}.");
            }
            context.Turnos.Remove(turno);
            await context.SaveChangesAsync();
            return Ok($"Turno con el Id: {id} eliminado correctamente.");
        }


    }
}
