using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models
{
    public class PedidoItem : Entity
    {
        public int PedidoId { get; set; }
        public int ProdutoID { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }





    }
}
