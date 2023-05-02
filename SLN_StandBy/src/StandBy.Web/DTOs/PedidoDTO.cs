using StandBy.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace StandBy.Web.DTOs
{
    public class PedidoDTO
    {

        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public char Status { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public decimal Valor { get; set; }

        //Relacao Cliente x Pedido
        public Cliente Cliente { get; set; }

        //Relacao Pedido X PedidosItens
        public IEnumerable<PedidoItem> PedidosItens { get; set; }

    }
}
