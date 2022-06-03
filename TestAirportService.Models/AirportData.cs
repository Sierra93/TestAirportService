using Newtonsoft.Json;

namespace TestAirportService.Models
{
    public class AirportData
    {
        public string Country { get; set; }

        [JsonProperty("city_iata")]
        public string CityData { get; set; }
        
        public string Iata { get; set; }
        
        public string City { get; set; }
        
        [JsonProperty("timezone_region_name")]
        public string TimezoneRegionName { get; set; }
        
        [JsonProperty("country_iata")]
        public string CountryIata { get; set; }
        
        public string Rating { get; set; }
        
        public string Name { get; set; }
        
        public Location Location { get; set; }
        
        public string Type { get; set; }
        
        public string Hubs { get; set; }
    }

    public class Location
    {
        public double Lon { get; set; }
        
        public double Lat { get; set; }
    }
}