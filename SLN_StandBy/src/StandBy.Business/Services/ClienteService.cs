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
        public async Task Adicionar(Cliente cliente)
        {
            if(!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if(_clienteRepository.Buscar(p => p.CpfCnpj == cliente.CpfCnpj).Result.Any())
            {
                Notificar("Já Existe um cliente com este Documento.");
                return;
            }
            await _clienteRepository.Adicionar(cliente);


        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;
            await _clienteRepository.Atualizar(cliente);

        }

        public async Task Remover(int id)
        {
            await _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
