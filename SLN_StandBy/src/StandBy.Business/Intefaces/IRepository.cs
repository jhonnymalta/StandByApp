using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Intefaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task<T> ObterPorId(int id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover(int id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);

        Task<int> SaveChanges();
    }
}
