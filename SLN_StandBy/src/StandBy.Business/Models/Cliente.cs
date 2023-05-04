using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models
{
    public class Cliente : Entity
    {
        public string CpfCnpj { get; set; }
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        //Relacao 1 CLIENTE Muitos PEDIDOS
        public IEnumerable<Pedido> Pedido { get; set; }

    }
}
