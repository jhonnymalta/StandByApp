using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StandBy.Web.DTOs;

namespace StandBy.Web.Services
{
    public interface IProdutosService
    {
        Task Adicionar(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> ObterPorId(int id);
        Task<List<ProdutoDTO>> ObterTodos();
        Task Atualizar(ProdutoDTO produtoDTO);
        Task Remover(int id);
        Task<IEnumerable<ProdutoDTO>> Buscar(Expression<Func<ProdutoDTO, bool>> predicate);

        Task<int> SaveChanges();
    }
}