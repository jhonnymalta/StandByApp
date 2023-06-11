using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Intefaces
{
    public interface IPedidoItemRepository : IRepository<PedidoItem>
    {

        Task<IEnumerable<PedidoItem>> ObterTodosPedidosPorId(int id);
        
        Task<IEnumerable<Produto>> ObterTodosProdutos();


        Task<Decimal> BuscarValorProduto(int id);
    }
}
