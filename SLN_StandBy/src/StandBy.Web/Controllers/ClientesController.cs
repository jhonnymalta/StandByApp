using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandBy.Business.Services;
using StandBy.Web.DTOs;

namespace StandBy.Web.Controllers
{
    
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteServices _clienteServices;
        private readonly IMapper _mapper;
        

        public ClientesController(IClienteRepository clienteRepository,IMapper mapper,IClienteServices clienteServices,INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteServices= clienteServices;
            _mapper = mapper;

            
            

        }
        
        [Route("lista-de-clientes")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos()));

        }



        [Route("novo-cliente")]
        public async Task<IActionResult> Create(ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid) return View(clienteDTO);
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteServices.Adicionar(cliente);
            return RedirectToAction("Index");

        }



        [Route("editar-cliente/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = _mapper.Map<ProdutoDTO>(await _clienteRepository.ObterPorId(id));

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }



        [Route("editar-cliente/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id) return NotFound();

            var clienteAtualizacao = await _clienteRepository.ObterPorId(id);
            clienteAtualizacao.CpfCnpj = cliente.CpfCnpj;
            clienteAtualizacao.Nome = cliente.Nome;
            clienteAtualizacao.Ativo = cliente.Ativo;

            if (!ModelState.IsValid) return View(cliente); 

            await _clienteServices.Atualizar(_mapper.Map<Cliente>(clienteAtualizacao));

            if (!OperacaoValida()) return View(cliente);

            return RedirectToAction("Index");
        }

        [Route("excluir-cliente/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ClienteDTO>(cliente));
        }



        [Route("excluir-cliente/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var cliente = await  _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteServices.Remover(cliente.Id);

            if (!OperacaoValida()) return View(cliente);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }


    }
}
