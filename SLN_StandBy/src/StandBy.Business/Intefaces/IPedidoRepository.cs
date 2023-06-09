﻿using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Intefaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Cliente>> ObterTodosClientes();
        Task<Pedido> ObterUmPedidoPorCliente(int id);
        
    }
}
