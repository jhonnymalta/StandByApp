using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StandBy.Web.DTOs
{
    public class ProdutoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        [JsonInclude]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        [JsonInclude]
        public string Descricao { get; set; }
        [JsonInclude]
        public int QuantidadeEstoque { get; set; }
        [JsonInclude]
        public Decimal Valor { get; set; }
    }
}
