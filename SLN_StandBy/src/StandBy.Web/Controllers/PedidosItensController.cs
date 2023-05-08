using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StandBy.Web.Services;
using StandBy.Web.DTOs;


namespace StandBy.Web.Controllers
{

    [Authorize]
    public class PedidosItensController : Controller
    {



        private readonly IPedidosItensService _pedidosItensServices;
        private readonly IProdutosService _produtosServices;
        private readonly IMapper _mapper;

        public PedidosItensController(IMapper mapper, IPedidosItensService pedidoItensService, IProdutosService produtosServices)
        {
            _pedidosItensServices = pedidoItensService;
            _produtosServices = produtosServices;
            _mapper = mapper;

        }



        [HttpGet("lista-de-item-do-pedido/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            List<PedidoItemDTO> item = _mapper.Map<List<PedidoItemDTO>>(await _pedidosItensServices.PegarTodosItemDePedido(id));

            return View(item);

        }




        [HttpGet("novo-item/{id:int}")]
        public async Task<IActionResult> Create(int id)
        {

            PedidoItemDTO pedidoItem = new PedidoItemDTO();
            pedidoItem.ListaProdutos = await _produtosServices.ObterTodos();
            pedidoItem.PedidoId = id;

            return View(pedidoItem);

        }


        [HttpPost("novo-item")]
        public async Task<IActionResult> Create(PedidoItemDTO pedidoItemDTO)
        {



            if (!ModelState.IsValid) return View(pedidoItemDTO);

            await _pedidosItensServices.Adicionar(pedidoItemDTO);
            return RedirectToAction("Create", "PedidosItens");

        }
        [HttpPost("add-item")]
        public async Task<IActionResult> CreateItem(PedidoItemDTO pedidoItemDTO)
        {
            if (!ModelState.IsValid) return View(pedidoItemDTO);

            await _pedidosItensServices.Adicionar(pedidoItemDTO);
            return RedirectToAction("Create", "PedidosItens");

        }

        [HttpPost("excluir-pedido-item/{id:int}")]
        public async Task<IActionResult> Delete(int id, ProdutoDTO produtoDTO)
        {

            var test = id;

            await _pedidosItensServices.Remover(id);

            TempData["Sucesso"] = "Produto excluido com sucesso!";
            return RedirectToAction("Index", "Produtos");

        }








    }
}
