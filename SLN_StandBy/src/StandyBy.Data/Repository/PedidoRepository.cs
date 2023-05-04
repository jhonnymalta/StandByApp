using Microsoft.EntityFrameworkCore;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandyBy.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(StandByDBContext context) : base(context) { }

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
    }
}
