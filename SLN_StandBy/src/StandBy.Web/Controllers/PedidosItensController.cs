using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandBy.Business.Services;
using StandBy.Web.DTOs;

namespace StandBy.Web.Controllers
{
    
    public class PedidosItemsController : BaseController
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoItemServices _pedidoItemServices;
        private readonly IMapper _mapper;
        

        public PedidosItemsController(IPedidoItemRepository pedidoItemRepository,IMapper mapper,IPedidoItemServices pedidoItemServices,INotificador notificador) : base(notificador)
        {
            _pedidoItemRepository = pedidoItemRepository;
            _pedidoItemServices= pedidoItemServices;
            _mapper = mapper;

        }

        
        [Route("lista-de-item-do-pedido")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PedidoItemDTO>>(await _pedidoItemRepository.ObterTodos()));

        }



        [Route("novo-item")]
        public async Task<IActionResult> Create(PedidoItemDTO pedidoItemDTO)
        {
            if (!ModelState.IsValid) return View(pedidoItemDTO);
            var pedidoItem = _mapper.Map<PedidoItem>(pedidoItemDTO);
            await _pedidoItemServices.Adicionar(pedidoItem);
            return RedirectToAction("Index");

        }



        [Route("editar-item/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var pedidoItem = _mapper.Map<PedidoItemDTO>(await _pedidoItemRepository.ObterPorId(id));

            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }



        [Route("editar-item/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PedidoItemDTO pedidoItem)
        {
            if (id != pedidoItem.Id) return NotFound();

            var pedidoItemAtualizacao = await _pedidoItemRepository.ObterPorId(id);
            pedidoItemAtualizacao.Quantidade = pedidoItem.Quantidade;
            

            if (!ModelState.IsValid) return View(pedidoItem); 

            await _pedidoItemServices.Atualizar(_mapper.Map<PedidoItem>(pedidoItemAtualizacao));

            if (!OperacaoValida()) return View(pedidoItem);

            return RedirectToAction("Index");
        }

        [Route("excluir-item/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoItem = await _pedidoItemRepository.ObterPorId(id);

            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PedidoItemDTO>(pedidoItem));
        }



        [Route("excluir-item/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var pedidoItem = await  _pedidoItemRepository.ObterPorId(id);

            if (pedidoItem == null)
            {
                return NotFound();
            }

            await _pedidoItemServices.Remover(pedidoItem.Id);

            if (!OperacaoValida()) return View(pedidoItem);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }


    }
}
