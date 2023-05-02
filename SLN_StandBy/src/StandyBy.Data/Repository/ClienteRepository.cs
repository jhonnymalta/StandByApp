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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(StandByDBContext context) : base(context) { }
    }
}
