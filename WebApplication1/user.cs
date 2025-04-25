using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace WebApplication1
{
    public class User : BaseModel
    {
        [PrimaryKey("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("age")]
        public string age { get; set; }
        [Column("city_id")]
        public int? city_id { get; set; }

    }
}