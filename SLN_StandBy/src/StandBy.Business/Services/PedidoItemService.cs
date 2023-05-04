using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandBy.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Services
{
    public class PedidoItemService : BaseService, IPedidoItemServices
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;

        public PedidoItemService(IPedidoItemRepository pedidoItemRepository, INotificador notificador) : base(notificador)
        {
            _pedidoItemRepository = pedidoItemRepository;

        }
        public async Task<bool> Adicionar(PedidoItem pedidoItem)
        {
            if (!ExecutarValidacao(new PedidoItemValidation(), pedidoItem)) return false;

            // if(_pedidoItemRepository.Buscar(p => p.Id == pedidoItem.Id).Result.Any())
            // {
            //     Notificar("Já Existe um produto com este código.");
            //     return false;
            // }
            await _pedidoItemRepository.Adicionar(pedidoItem);
            return true;

        }

        public async Task<bool> Atualizar(PedidoItem pedidoItem)
        {
            if (!ExecutarValidacao(new PedidoItemValidation(), pedidoItem)) return false;
            await _pedidoItemRepository.Atualizar(pedidoItem);
            return true;

        }

        public async Task<bool> Remover(int id)
        {
            var produto = await _pedidoItemRepository.ObterPorId(id);
            if (produto == null) return false;
            await _pedidoItemRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pedidoItemRepository?.Dispose();
        }
    }
}
