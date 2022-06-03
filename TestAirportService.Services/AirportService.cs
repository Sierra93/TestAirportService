using System;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestAirportService.Abstractions;
using TestAirportService.Models;

namespace TestAirportService.Services
{
    /// <summary>
    /// Класс реализует методы сервиса аэропортов.
    /// </summary>
    public class AirportService : IAirportService
    {
        /// <summary>
        /// Метод вычислит расстояние между аэропортами в милях.
        /// </summary>
        /// <returns>Число расстояния.</returns>
        public async Task<AirportOutput> CalcDifferenceAsync()
        {
            try
            {
                var result = new AirportOutput();
                var dif1 = new Location();
                var dif2 = new Location();

                var request = (HttpWebRequest)WebRequest.Create("https://places-dev.cteleport.com/airports/SVO");
                var response = (HttpWebResponse)await request.GetResponseAsync();

                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var res = await reader.ReadToEndAsync();
                            var data = JsonConvert.DeserializeObject<AirportData>(res);
                            
                            if (data != null)
                            {
                                dif1.Lon = data.Location.Lon;
                                dif1.Lat = data.Location.Lat;
                            }
                        }
                    }
                }

                response.Close();
                
                var request2 = (HttpWebRequest)WebRequest.Create("https://places-dev.cteleport.com/airports/LED");
                var response2 = (HttpWebResponse)await request2.GetResponseAsync();

                using (var stream = response2.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var res = await reader.ReadToEndAsync();
                            var data = JsonConvert.DeserializeObject<AirportData>(res);
                            
                            if (data != null)
                            {
                                dif2.Lon = data.Location.Lon;
                                dif2.Lat = data.Location.Lat;
                            }
                        }
                    }
                }

                response2.Close();
                
                // Вычислит расстояние в милях.
                var a = new GeoCoordinate(30.6, 59.983333);
                var b = new GeoCoordinate(37.416574, 55.966324);
                
                // Получит из метров мили.
                result.Difference = a.GetDistanceTo(b) / 1609;

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}