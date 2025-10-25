using ProyectoManicura2025V4.BD.Datos.Entidades;
using ProyectoManicura2025V4.Shared.DTO;

namespace ProyectoManicura2025V4.Repositorio.Repositorios
{
    public interface ITurnoRepositorio : IRepositorio<Turno>
    {
        Task<List<TurnoListadoDTO>> ObtenerListaTurnosDTO();
    }
}