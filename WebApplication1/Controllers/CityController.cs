using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly SupaBaseContext _supabaseContext;

        public CityController(Supabase.Client supabaseClient, SupaBaseContext supaBaseContext)
        {
            _supabaseClient = supabaseClient;
            _supabaseContext = supaBaseContext;
        }

        [HttpGet("GetAllCities", Name = "GetAllCities")]
        public async Task<string> GetAllCities()
        {
            try
            {
                var cities = await _supabaseContext.GetAllCities(_supabaseClient);
                return JsonConvert.SerializeObject(cities, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            }
        }

        [HttpPost("AddCity", Name = "AddCity")]
        public async Task<string> AddCity([FromBody] City newCity)
        {
            if (newCity == null)
                return JsonConvert.SerializeObject(new { error = "City data is required" }, Formatting.Indented);

            try
            {
                var city = await _supabaseContext.AddCity(_supabaseClient, newCity);
                return JsonConvert.SerializeObject(city, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            }
        }

        [HttpDelete("DeleteCity", Name = "DeleteCity")]
        public async Task<string> DeleteCity(int id)
        {
            try
            {
                await _supabaseContext.DeleteCity(_supabaseClient, id);
                return JsonConvert.SerializeObject(new { success = true }, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, error = ex.Message }, Formatting.Indented);
            }
        }

        [HttpPut("UpdateCity", Name = "UpdateCity")]
        public async Task<string> UpdateCity([FromBody] City city)
        {
            try
            {
                var updatedCity = await _supabaseContext.UpdateCity(_supabaseClient, city);
                return JsonConvert.SerializeObject(updatedCity, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            }
        }
    }
}
