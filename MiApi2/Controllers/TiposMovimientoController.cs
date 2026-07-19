
using Microsoft.AspNetCore.Mvc;
using MiApi2.Models;

namespace MiApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposMovimientoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TipoMovimiento>> Get()
        {
           var lista = new List<TipoMovimiento>
        {
        new TipoMovimiento { Codigo = 29, Descripcion = "Ajuste al Inventario", VActiva = false },
        new TipoMovimiento { Codigo = 51, Descripcion = "Avance Produccion", VActiva = false },
        new TipoMovimiento { Codigo = 17, Descripcion = "Balance Inicial", VActiva = false },
        new TipoMovimiento { Codigo = 12, Descripcion = "Devolucion de Cliente", VActiva = true },
        new TipoMovimiento { Codigo = 8, Descripcion = "Traslado entre Bodegas", VActiva = true }
        };


            return Ok(lista);
        }
    }
}