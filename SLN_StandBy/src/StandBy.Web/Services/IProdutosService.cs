using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StandBy.Web.DTOs;

namespace StandBy.Web.Services
{
    public interface IProdutosService : IDisposable
    {
        Task<string> Adicionar(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> ObterPorId(int id);
        Task<List<ProdutoDTO>> ObterTodos();
        Task<string> Atualizar(int id, ProdutoDTO produtoDTO);
        Task<string> Remover(int id);
        Task<IEnumerable<ProdutoDTO>> Buscar(Expression<Func<ProdutoDTO, bool>> predicate);

        Task<int> SaveChanges();
    }
}