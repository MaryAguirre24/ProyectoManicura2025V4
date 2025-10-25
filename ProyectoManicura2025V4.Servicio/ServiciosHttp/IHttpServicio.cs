
namespace ProyectoManicura2025V4.Servicio.ServiciosHttp
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}