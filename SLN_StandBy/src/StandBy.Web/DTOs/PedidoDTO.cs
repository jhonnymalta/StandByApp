using StandBy.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace StandBy.Web.DTOs
{
    public class PedidoDTO
    {

        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public IEnumerable<ClienteDTO> ListaDeCliente { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public char Status { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public decimal Valor { get; set; }





    }
}
