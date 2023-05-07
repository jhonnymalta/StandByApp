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
    public class ClienteService : BaseService, IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;

        }
        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            if (_clienteRepository.Buscar(p => p.CpfCnpj == cliente.CpfCnpj).Result.Any())
            {
                Notificar("Já Existe um cliente com este Documento.");
                return false;
            }
            await _clienteRepository.Adicionar(cliente);
            return true;

        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;
            await _clienteRepository.Atualizar(cliente);
            return true;

        }

        public async Task<bool> Remover(int id)
        {
            var produto = await _clienteRepository.ObterPorId(id);
            if (produto == null) return false;
            await _clienteRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
