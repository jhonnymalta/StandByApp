using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StandBy.Web.Services;
using StandBy.Web.DTOs;


namespace StandBy.Web.Controllers
{


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
        public async Task<IActionResult> Index(int id, PedidoDTO pedidoDto)
        {
            //pedidoDto = _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterPorId(id));

            return View(pedidoDto);

        }




        [HttpGet("novo-item/{id:int}")]
        public async Task<IActionResult> Create()
        {

            PedidoItemDTO pedidoItem = new PedidoItemDTO();
            pedidoItem.ListaProdutos = await _produtosServices.ObterTodos();
            return View(pedidoItem);

        }


        [HttpPost("novo-item/{id:int}")]
        public async Task<IActionResult> Create(PedidoItemDTO pedidoItemDTO)
        {

            if (!ModelState.IsValid) return View(pedidoItemDTO);

            await _pedidosItensServices.Adicionar(pedidoItemDTO);
            return RedirectToAction("Create", "PedidosItens");

        }








    }
}
