using System.ComponentModel.DataAnnotations;
using StandBy.Business.Models;

namespace StandyBy.Api.DTOs
{
    public class PedidoDTO
    {

        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        public char Status { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal Valor { get; set; }








    }
}
