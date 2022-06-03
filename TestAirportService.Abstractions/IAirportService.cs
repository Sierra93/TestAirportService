using System.Threading.Tasks;
using TestAirportService.Models;

namespace TestAirportService.Abstractions
{
    /// <summary>
    /// Абстракция сервиса при работе с аэропортами.
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Метод вычислит расстояние между аэропортами в милях.
        /// </summary>
        /// <returns>Число расстояния.</returns>
        Task<AirportOutput> CalcDifferenceAsync();
    }
}