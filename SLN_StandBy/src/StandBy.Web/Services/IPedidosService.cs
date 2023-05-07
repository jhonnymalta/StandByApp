using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StandBy.Web.DTOs;
using StandBy.Web.Models;

namespace StandBy.Web.Services
{
    public interface IPedidosService : IDisposable
    {
        Task<string> Adicionar(Pedido produto);
        Task<PedidoDTO> ObterPorId(int id);
        Task<List<PedidoDTO>> ObterTodos();
        Task<string> Atualizar(int id, PedidoDTO produtoDTO);
        Task<string> Remover(int id);
        Task<IEnumerable<ClienteDTO>> BuscarListaDeCliente();
        Task<int> SaveChanges();
    }
}