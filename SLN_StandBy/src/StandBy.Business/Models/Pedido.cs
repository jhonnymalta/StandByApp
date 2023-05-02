using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models
{
    public class Pedido : Entity
    {
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        public char Status { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal Valor { get; set; }

        //Relacao Cliente x Pedido
        public Cliente Cliente { get; set; }

        //Relacao Pedido X PedidosItens
        public IEnumerable<PedidoItem> PedidosItens { get; set; }

    }
}
