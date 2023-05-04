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
    public class PedidoService : BaseService, IPedidoServices
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;

        }
        public async Task<bool> Adicionar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return false;

            // if(_pedidoRepository.Buscar(p => p.Id == pedido.Id).Result.Any())
            // {
            //     Notificar("Já Existe um produto com este código.");
            //     return false;
            // }
            await _pedidoRepository.Adicionar(pedido);
            return true;

        }

        public async Task<bool> Atualizar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return false;
            await _pedidoRepository.Atualizar(pedido);
            return true;

        }

        public async Task<bool> Remover(int id)
        {
            var produto = await _pedidoRepository.ObterPorId(id);
            if (produto == null) return false;
            await _pedidoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pedidoRepository?.Dispose();
        }
    }
}
