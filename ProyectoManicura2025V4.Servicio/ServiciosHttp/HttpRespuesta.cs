using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.Servicio.ServiciosHttp
{
    public class HttpRespuesta<T>
    {
        public HttpRespuesta(T? respuesta, bool error,HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public string ObtenerError()
        { 
            if(!Error)
            {
                return string.Empty;
            }
            else 
            { 
                var statudCode = HttpResponseMessage.StatusCode;
                switch(statudCode)
                {
                    case HttpStatusCode.NotFound:
                        return "Recurso no encontrado.";
                    case HttpStatusCode.BadRequest:
                        return "Solicitud incorrecta.";
                    case HttpStatusCode.InternalServerError:
                        return "Error interno del servidor.";
                    case HttpStatusCode.Unauthorized:
                        return "No autorizado.";
                    default:
                        return $"Error desconocido. Código de estado: {statudCode}";
                }
            }
        }
    }
}
     