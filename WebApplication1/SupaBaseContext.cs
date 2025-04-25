using Supabase.Postgrest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class SupaBaseContext
    {
        public async Task<List<User>> GetAllUsers(Supabase.Client client)
        {
            var result = await client.From<User>().Get();
            return result.Models;
        }

        public async Task<User> AddUser(Supabase.Client client, User newUser)
        {
            var response = await client.From<User>().Insert(newUser);
            return response.Models.FirstOrDefault();
        }

        public async Task DeleteUser(Supabase.Client client, int id)
        {
            await client.From<User>()
                .Where(u => u.id == id)
                .Delete();
        }

        public async Task<User> UpdateUser(Supabase.Client client, User user)
        {
            await client.From<User>()
                .Where(u => u.id == user.id)
                .Update(user);

            return await client.From<User>()
                .Where(u => u.id == user.id)
                .Single();
        }

        public async Task<List<City>> GetAllCities(Supabase.Client client)
        {
            var result = await client.From<City>().Get();
            return result.Models;
        }

        public async Task<City> AddCity(Supabase.Client client, City newCity)
        {
            var response = await client.From<City>().Insert(newCity);
            return response.Models.FirstOrDefault();
        }

        public async Task DeleteCity(Supabase.Client client, int id)
        {
            await client.From<City>()
                .Where(c => c.id == id)
                .Delete();
        }

        public async Task<City> UpdateCity(Supabase.Client client, City City)
        {
            await client.From<City>()
                .Where(c => c.id == City.id)
                .Update(City);

            return await client.From<City>()
                .Where(c => c.id == City.id)
                .Single();
        }
    }
}