using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wikisuplementos.Models
{
    public class AtletaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public string? LinkFoto { get; set; }

        public string? Uf { get; set; }

        // Chave estrangeira para Treinador
        public int TreinadorId { get; set; }
        public TreinadorModel Treinador { get; set; }
    }
}
