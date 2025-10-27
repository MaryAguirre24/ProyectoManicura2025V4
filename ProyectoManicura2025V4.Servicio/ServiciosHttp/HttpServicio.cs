using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.Servicio.ServiciosHttp
{
    public class HttpServicio : IHttpServicio
    {
        private readonly HttpClient http;

        public HttpServicio(HttpClient Http)
        {
            http = Http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, response);
            }

        }

        public async Task<HttpRespuesta<TResp>> Post<T, TResp>(string url, T entidad)
        { 
            var JasonAEnviar = JsonSerializer.Serialize(entidad);
            var contenido = new StringContent(JasonAEnviar, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(url, contenido);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<TResp>(response);
                return new HttpRespuesta<TResp>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<TResp>(default, true, response);
            }
        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var resp= await  http.DeleteAsync(url);
            return new HttpRespuesta<object>(null, !resp.IsSuccessStatusCode, resp);
        }
        
        private async Task<T?> DesSerializar<T>(HttpResponseMessage response)
        {
            var respString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respString,
              new JsonSerializerOptions
              {
                  PropertyNameCaseInsensitive = true
              });
        }
    }
}
