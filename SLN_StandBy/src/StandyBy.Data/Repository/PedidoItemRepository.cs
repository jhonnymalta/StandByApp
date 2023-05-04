using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Data.Context;
using Microsoft.Data.Sql;
using Dapper;
using Microsoft.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StandyBy.Data.Repository
{
    public class PedidoItemRepository : Repository<PedidoItem>, IPedidoItemRepository
    {
        public PedidoItemRepository(StandByDBContext context) : base(context) { }
        SqlConnection dapperConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=DB_StandyBy_TesteJhonatan;Trusted_Connection=True;MultipleActiveResultSets=true");

        public async Task<IEnumerable<PedidoItem>> ObterTodosPedidosPorId(int id)
        {
            List<PedidoItem> pedidoItems = new List<PedidoItem>();
            var pars = new { id = id };
            var sqlqueryGetAllPedidosItem = "select * from PedidosItens with(nolock) where PedidoId = @id ";
            pedidoItems = dapperConnection.Query<PedidoItem>(sqlqueryGetAllPedidosItem, pars).ToList();
            return pedidoItems;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            List<Produto> produtosList = new List<Produto>();

            var sqlqueryGetAllPedidosItem = "select * from Produtos with(nolock) ";
            produtosList = dapperConnection.Query<Produto>(sqlqueryGetAllPedidosItem).ToList();
            return produtosList;
        }

        public async Task<decimal> BuscarValorProduto(int id)
        {
            var sqlqueryGetAllPedidosItem = "select top 1 Valor from Produtos with(nolock) where Id = @id ";
            var pars = new { id = id };
            var valor = await dapperConnection.QueryFirstOrDefaultAsync<decimal>(sqlqueryGetAllPedidosItem, pars);
            return valor;
        }
    }
}
