using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models
{
    public class Produto : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public Decimal Valor { get; set; }
    }
}
