using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandBy.Web.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        public char Status { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal Valor { get; set; }


    }
}