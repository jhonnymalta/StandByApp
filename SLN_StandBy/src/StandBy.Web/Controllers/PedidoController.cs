using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandBy.Business.Services;
using StandBy.Web.DTOs;

namespace StandBy.Web.Controllers
{
    
    public class PedidoController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoServices _pedidoServices;
        private readonly IMapper _mapper;
        

        public PedidoController(IPedidoRepository pedidoRepository,IMapper mapper,IPedidoServices pedidoServices,INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoServices= pedidoServices;
            _mapper = mapper;

        }

        
        [Route("lista-de-pedidos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterTodos()));

        }



        [Route("novo-pedido")]
        public async Task<IActionResult> Create(PedidoDTO pedidoDTO)
        {
            if (!ModelState.IsValid) return View(pedidoDTO);
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            await _pedidoServices.Adicionar(pedido);
            return RedirectToAction("Index");

        }



        [Route("editar-pedido/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var pedido = _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterPorId(id));

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }



        [Route("editar-pedido/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PedidoDTO pedido)
        {
            if (id != pedido.Id) return NotFound();

            var pedidoAtualizacao = await _pedidoRepository.ObterPorId(id);
            pedidoAtualizacao.ClienteId = pedido.ClienteId;
            pedidoAtualizacao.Data = pedido.Data;
            pedidoAtualizacao.Status = pedido.Status;
            pedidoAtualizacao.DataAtualizacao = pedido.DataAtualizacao;
            pedidoAtualizacao.Cliente = pedido.Cliente;
            pedidoAtualizacao.PedidosItens = pedido.PedidosItens;

            if (!ModelState.IsValid) return View(pedido); 

            await _pedidoServices.Atualizar(_mapper.Map<Pedido>(pedidoAtualizacao));

            if (!OperacaoValida()) return View(pedido);

            return RedirectToAction("Index");
        }

        [Route("excluir-pedido/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PedidoDTO>(pedido));
        }



        [Route("excluir-pedido/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var pedido = await  _pedidoRepository.ObterPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            await _pedidoServices.Remover(pedido.Id);

            if (!OperacaoValida()) return View(pedido);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }


    }
}
