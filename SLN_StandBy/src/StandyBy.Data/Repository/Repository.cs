using Microsoft.EntityFrameworkCore;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StandyBy.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly StandByDBContext _dbContext;
        protected readonly DbSet<T> Dbset;

        protected Repository(StandByDBContext dbContext)
        {
            _dbContext = dbContext;
            Dbset = _dbContext.Set<T>();
        }


        public virtual async Task<List<T>> ObterTodos()
        {
            return await Dbset.ToListAsync();

        }
        public virtual async Task<T> ObterPorId(int id)
        {
            return await Dbset.FindAsync(id);
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(T entity)
        {
            Dbset.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(T entity)
        {
            Dbset.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(int id)
        {
            Dbset.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
