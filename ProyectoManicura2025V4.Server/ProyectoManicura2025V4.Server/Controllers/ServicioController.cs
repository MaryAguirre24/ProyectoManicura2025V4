using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;

namespace ProyectoManicura2025V4.Server.Controllers
{
    [ApiController]
    [Route("api/servicioE")]
    public class ServicioEController : ControllerBase
    {
        private readonly AppDbContext context;

        public ServicioEController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicioE>>> GetServicio()
        {
            var servicios = await context.Servicios.ToListAsync();
            if (servicios == null)
            {
                return BadRequest("Error al obtener los servicios.");
            }
            if (servicios.Count == 0)
            {
                return NotFound("No se encontraron servicios.");
            }
            return Ok(servicios);
        }
        [HttpPut]   
        public async Task<ActionResult> PutServicio(ServicioE servicio)
        {
            var servicioExistente = await context.Servicios.FirstOrDefaultAsync(s => s.Id == servicio.Id);
            if (servicioExistente == null)
            {
                return NotFound("Servicio no encontrado.");
            }
            servicioExistente.NombreServicio = servicio.NombreServicio;
            servicioExistente.Precio = servicio.Precio;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
    

}
