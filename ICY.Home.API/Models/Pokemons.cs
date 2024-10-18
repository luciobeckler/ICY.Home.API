using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace ICY.Home.API.Models
{
    public class Pokemons
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName ="nvarchar(15)")]
        public string nome { get; set; } = string.Empty;
        [Column]
        public int levelEvolucao { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? condicaoEvolucao { get; set; }
        [Column]
        public int? idPokemoEvolucao { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string tiposSerializados { get; set; } = string.Empty;

        [NotMapped]
        public List<string> tipos
        {
            get => string.IsNullOrEmpty(tiposSerializados) ? 
                new List<string>() : 
                JsonSerializer.Deserialize<List<string>>(tiposSerializados);

            set => tiposSerializados = JsonSerializer.Serialize(value);
        }
    }
}
