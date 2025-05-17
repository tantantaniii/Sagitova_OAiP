using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly SupaBaseContext _supabaseContext;

        public UserController(Supabase.Client supabaseClient, SupaBaseContext supaBaseContext)
        {
            _supabaseClient = supabaseClient;
            _supabaseContext = supaBaseContext;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<string> GetAllUsers()
        {
            try
            {
                var users = await _supabaseContext.GetAllUsers(_supabaseClient);
                return JsonConvert.SerializeObject(users, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            }
        }

        [HttpPost("AddUser", Name = "AddUser")]
        public async Task<string> AddUser([FromBody] User newUser)
        {
            if (newUser == null)
                return JsonConvert.SerializeObject(new { error = "User data is required" }, Formatting.Indented);

            try
            {
                var user = await _supabaseContext.AddUser(_supabaseClient, newUser);
                return JsonConvert.SerializeObject(user, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            }
        }

        [HttpDelete("DeleteUser", Name = "DeleteUser")]
        public async Task<string> DeleteUser(int id)
        {
            try
            {
                await _supabaseContext.DeleteUser(_supabaseClient, id);
                return JsonConvert.SerializeObject(new { success = true }, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, error = ex.Message }, Formatting.Indented);
            }
        }

        [HttpPut("UpdateUser", Name = "UpdateUser")]
        public async Task<string> UpdateUser([FromBody] User user)
        {
            try
            {
                var updatedUser = await _supabaseContext.UpdateUser(_supabaseClient, user);
                return JsonConvert.SerializeObject(updatedUser, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            }
        }
    }
}