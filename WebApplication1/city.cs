using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace WebApplication1
{
    public class City : BaseModel
    {
        [PrimaryKey("id")]
        public int id { get; set; }
        [Column("name_of_city")]
        public string name_of_city { get; set; }

    }
}