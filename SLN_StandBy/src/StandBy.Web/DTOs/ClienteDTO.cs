using System.ComponentModel.DataAnnotations;

namespace StandBy.Web.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
      
    }
}
