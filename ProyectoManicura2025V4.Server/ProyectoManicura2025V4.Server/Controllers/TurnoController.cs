using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;

namespace ProyectoManicura2025V4.Server.Controllers
{
    [ApiController]
    [Route("api/Turno")]
    public class TurnoController : ControllerBase
    {
        private readonly AppDbContext context;

        public TurnoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turno>>> Get()
        {
            var listaturnos = await context.Turnos.ToListAsync();
            if (listaturnos == null)
            {
                return BadRequest("Error al obtener los turnos.");
            }
            if (listaturnos.Count == 0)
            {
                return NotFound("No se encontraron turnos.");
            }
            return Ok(listaturnos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Turno>> GetById(int id)
        {
            var entidad = await context.Turnos.FirstOrDefaultAsync(t => t.Id == id);
            if (entidad == null)
            {
                return NotFound($"No se encontro el turno con el Id: {id}.");
            }
            return Ok(entidad);

        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Turno DTO)
        {
            try
            {
                await context.Turnos.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, Turno DTO)
        {
            if (id != DTO.Id)
            {
                return BadRequest("Datos no validos.");
            }
            var turnoExistente = await context.Turnos.FirstOrDefaultAsync(t => t.Id == id);
            if (turnoExistente == null)
            {
                return NotFound("No se encontro el turno.");
            }
            context.Update(DTO);
            await context.SaveChangesAsync();
            return Ok();
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
