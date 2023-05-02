using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Intefaces
{
    public interface IProdutoServices : IDisposable
    {
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Remover(int id);
    }
}
