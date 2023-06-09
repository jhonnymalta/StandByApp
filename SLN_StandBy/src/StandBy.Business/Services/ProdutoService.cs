using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandBy.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StandBy.Business.Services
{
    public class ProdutoService : BaseService, IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;

        }
        public async Task<bool> Adicionar(Produto produto)
        {
            if(!ExecutarValidacao(new ProdutoValidation(), produto)) return false;
           
            await _produtoRepository.Adicionar(produto);
            return true;

        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;
            await _produtoRepository.Atualizar(produto);
            return true;

        }

        public async Task<bool> Remover(int id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            if(produto == null) return false;
            await _produtoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
