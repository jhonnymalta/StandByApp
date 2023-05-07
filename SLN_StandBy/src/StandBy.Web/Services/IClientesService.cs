using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StandBy.Web.DTOs;

namespace StandBy.Web.Services
{
    public interface IClientesService : IDisposable
    {
        Task<string> Adicionar(ClienteDTO produtoDTO);
        Task<ClienteDTO> ObterPorId(int id);
        Task<List<ClienteDTO>> ObterTodos();
        Task<string> Atualizar(int id, ClienteDTO produtoDTO);
        Task<string> Remover(int id);
        Task<IEnumerable<ClienteDTO>> Buscar(Expression<Func<ClienteDTO, bool>> predicate);

        Task<int> SaveChanges();
    }
}