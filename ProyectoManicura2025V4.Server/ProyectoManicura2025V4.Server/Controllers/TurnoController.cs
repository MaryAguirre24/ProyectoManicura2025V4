using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;
using ProyectoManicura2025V4.Repositorio.Repositorios;

namespace ProyectoManicura2025V4.Server.Controllers
{
    [ApiController]
    [Route("api/Turno")]
    public class TurnoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Turno> repositorio;

        public TurnoController(AppDbContext context,IRepositorio<Turno> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turno>>> Getturno()
        {
            var turnos = await repositorio.Select();
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Turno>> GetById(int id)
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
        public async Task<ActionResult<int>> Post(Turno DTO)
        {
            try
            {
                var id = await repositorio.Insert(DTO);
                //await context.Turnos.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);

            }
            catch (Exception e)
            {
                return BadRequest($"Error al reservar el turno{e.Message}");
            }

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, Turno DTO)
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
