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
        public async Task<IActionResult> Create()
        {

            PedidoItemDTO pedidoItem = new PedidoItemDTO();
            pedidoItem.ListaProdutos = await _produtosServices.ObterTodos();
            ViewData["pedido"] = pedidoItem.PedidoId;
            return View(pedidoItem);

        }


        [HttpPost("novo-item")]
        public async Task<IActionResult> Create(PedidoItemDTO pedidoItemDTO)
        {



            if (!ModelState.IsValid) return View(pedidoItemDTO);

            await _pedidosItensServices.Adicionar(pedidoItemDTO);
            return RedirectToAction("Create", "PedidosItens");

        }








    }
}
