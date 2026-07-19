using System.Net.Http.Json;
using RetoTecnico.Models;

namespace RetoTecnico.Services
{
    public class TipoMovimientoService
    {
        private readonly HttpClient _httpClient;

        public TipoMovimientoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TipoMovimiento>> ObtenerTiposMovimientoAsync()
        {
        var resultado = await _httpClient.GetFromJsonAsync<List<TipoMovimiento>>("api/tiposmovimiento");            return resultado ?? new List<TipoMovimiento>();
        }
    }
}