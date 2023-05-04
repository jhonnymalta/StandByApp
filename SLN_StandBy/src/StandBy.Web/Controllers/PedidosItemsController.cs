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

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoItemServices _pedidoItemServices;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;


        public PedidosItemsController(IPedidoItemRepository pedidoItemRepository,
        IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository,
        IMapper mapper, IPedidoItemServices pedidoItemServices, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoItemRepository = pedidoItemRepository;
            _pedidoItemServices = pedidoItemServices;
            _produtoRepository = produtoRepository;
            _mapper = mapper;

        }


        [Route("lista-de-item-do-pedido/{id:int}")]
        public async Task<IActionResult> Index(int id, PedidoDTO pedidoDto)
        {
            pedidoDto = _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterPorId(id));
            pedidoDto.PedidosItens = _mapper.Map<IEnumerable<PedidoItem>>(await _pedidoItemRepository.ObterTodosPedidosPorId(id));
            return View(pedidoDto);



        }








        [Route("novo-item")]
        public async Task<IActionResult> Create()
        {
            PedidoItemDTO pedidoItemDto = new PedidoItemDTO();
            ProdutoDTO produtosList = new ProdutoDTO();
            pedidoItemDto.ListaProdutos = _mapper.Map<IEnumerable<Produto>>(await _pedidoItemRepository.ObterTodosProdutos());
            return View("AddItem", pedidoItemDto);
        }




        [Route("novo-item")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PedidoItemDTO pedidoItemDTO)
        {


            PedidoItem pedidoItem = new PedidoItem();
            ProdutoDTO produtoDTO = new ProdutoDTO();
            // produtoItem = _produtoRepository.ObterPorId()
            pedidoItem = _mapper.Map<PedidoItem>(pedidoItemDTO);
            pedidoItem.PedidoId = pedidoItemDTO.PedidoId;
            pedidoItem.Quantidade = pedidoItemDTO.Quantidade;
            // pedidoItem.ValorUnitario = await _pedidoItemRepository.BuscarValorProduto(pedidoItemDTO.PedidoId);
            pedidoItem.ValorTotal = (pedidoItem.ValorUnitario * pedidoItem.Quantidade);

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
            var pedidoItem = await _pedidoItemRepository.ObterPorId(id);

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
