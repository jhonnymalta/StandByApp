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
    public class PedidoItemRepository : Repository<PedidoItem>, IPedidoItemRepository
    {
        public PedidoItemRepository(StandByDBContext context) : base(context) { }
    }
}
