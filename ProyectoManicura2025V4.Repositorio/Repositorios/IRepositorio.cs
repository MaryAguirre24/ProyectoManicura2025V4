using ProyectoManicura2025V4.BD.Datos;

namespace ProyectoManicura2025V4.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntitybase
    {
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> SelectListaTurno();
        Task<E?> SelectById(int id);
        Task<bool> Update(int id, E entidad);
    }
}