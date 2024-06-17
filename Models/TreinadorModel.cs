using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace wikisuplementos.Models
{
    public class TreinadorModel
    {
        public TreinadorModel()
        {
            Atletas = new List<AtletaModel>();
        }
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }  // Propriedades anuláveis
        public string? Descricao { get; set; }
        public string? LinkFoto { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }

        [JsonIgnore]
        public ICollection<AtletaModel> Atletas { get; set; }
    }
}
