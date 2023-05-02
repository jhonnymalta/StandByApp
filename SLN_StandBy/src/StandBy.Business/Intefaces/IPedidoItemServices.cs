using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Intefaces
{
    public interface IPedidoItemServices : IDisposable
    {
        Task<bool> Adicionar(PedidoItem pedidoItem);
        Task<bool> Atualizar(PedidoItem pedidoItem);
        Task<bool> Remover(int id);
    }
}
