using System.ComponentModel.DataAnnotations;

namespace wikisuplementos.Models
{
    public class SuplementosModel
    {
        [Key]
        public int Id { get; set; }
        
        public string? Nome { get; set; }  // Propriedades anuláveis
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public string? LinkFoto { get; set; }
        public string? Grupo { get; set; }
        public string? Fabricante { get; set; }
    }
}
