using System.Text.Json.Serialization;

namespace SongListApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
            
            [JsonIgnore]
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
