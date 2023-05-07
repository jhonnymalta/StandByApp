using StandBy.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace StandyBy.Api.DTOs
{
    public class PedidoItemDTO
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public int ProdutoID { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }


        //Relacao PedidoItem x Pedido
        public Pedido Pedido { get; set; }

        
    }
}
