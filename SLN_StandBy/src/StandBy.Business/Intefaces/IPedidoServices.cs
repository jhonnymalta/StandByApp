using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Intefaces
{
    public interface IPedidoServices : IDisposable
    {
        Task<bool> Adicionar(Pedido pedido);      
        Task<bool> Atualizar(Pedido pedido);
        Task<bool> Remover(int id);
    }
}
