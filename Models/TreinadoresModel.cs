using System.ComponentModel.DataAnnotations;

namespace wikisuplementos.Models
{
    public class TreinadoresModel
    {
        [Key]
        public int Id { get; set; }
        
        public string? Nome { get; set; }  // Propriedades anuláveis
        public string? Descricao { get; set; }
        public string? LinkFoto { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
    }
}
