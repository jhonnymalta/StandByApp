using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StandBy.Web.DTOs;
using StandBy.Web.Models;

namespace StandBy.Web.Services
{
    public interface IPedidosItensService : IDisposable
    {
        Task<string> Adicionar(PedidoItemDTO pedidoItemDTO);

        Task<string> Remover(int id);

        Task<int> SaveChanges();
        Task<IEnumerable<PedidoItemDTO>> PegarTodosItemDePedido(int id);
    }
}