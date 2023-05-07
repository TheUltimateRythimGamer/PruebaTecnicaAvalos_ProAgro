using Data;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAvalos.Dto;
using PruebaTecnicaAvalos.Request;

namespace PruebaTecnicaAvalos.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : Controller
    {
        private ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<ActionResult> Guardar([FromBody] LocationRequest request)
        {
            try
            {
                Location model = new Location()
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Raking = request.Raking,
                    RutaImagen = request.RutaImagen
                };

                bool isCorrect = await _locationService.Guardar(model.Id, model);

                if (isCorrect)
                    return Ok(new { mensaje = "OK" });
                else
                    return BadRequest(new { mensaje = "Error al guardar" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                ICollection<Location> items = _locationService.GetLocations();
                List<LocationDto> result = new List<LocationDto>();

                foreach (var item in items)
                {
                    result.Add(new LocationDto
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Raking = item.Raking,
                        RutaImagen = item.RutaImagen
                    });
                }

                return Ok(new { mensaje = "OK", Listado = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet]
        [Route("{locationId}")]
        public async Task<ActionResult> GetById(string locationId)
        {
            try
            {
                Location location = _locationService.GetLocation(locationId);

                if (location == null)
                    return Ok(new { mensaje = "OK" });
                else
                {
                    LocationDto result = new LocationDto()
                    {
                        Id = location.Id,
                        Nombre = location.Nombre,
                        Raking = location.Raking,
                        RutaImagen = location.RutaImagen
                    };
                    return Ok(new { mensaje = "OK", result = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}
