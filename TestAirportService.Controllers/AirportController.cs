using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAirportService.Abstractions;
using TestAirportService.Models;

namespace TestAirportService.Controllers
{
    /// <summary>
    /// Контроллер работы с аэропортами.
    /// </summary>
    [ApiController, Route("air")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        
        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        /// <summary>
        /// Метод вычислит расстояние между аэропортами в милях.
        /// </summary>
        /// <returns>Число расстояния.</returns>
        [HttpGet]
        [Route("difference")]
        public async Task<AirportOutput> DifferenceAirportsAsync()
        {
            var result = await _airportService.CalcDifferenceAsync();

            return result;
        }
    }
}