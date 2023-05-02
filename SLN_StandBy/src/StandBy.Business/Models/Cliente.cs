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
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public Pedido Pedido { get; set; }

    }
}
