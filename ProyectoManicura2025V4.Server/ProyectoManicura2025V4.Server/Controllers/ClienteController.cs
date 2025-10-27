using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;

namespace ProyectoManicura2025V4.Server.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetCliente()
        {
            var clientes = await context.Clientes.ToListAsync();
            if (clientes == null)
            {
                return BadRequest("Error al obtener los clientes.");
            }
            if (clientes.Count == 0)
            {
                return NotFound("No se encontraron clientes.");
            }
            return Ok(clientes);
        }
    }
}
