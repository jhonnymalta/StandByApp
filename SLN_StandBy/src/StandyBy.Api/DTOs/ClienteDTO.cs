using System.ComponentModel.DataAnnotations;
using StandBy.Business.Models;

namespace StandyBy.Api.DTOs
{
    public class ClienteDTO
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }







    }
}
