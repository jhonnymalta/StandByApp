
using Microsoft.AspNetCore.Mvc;
using StandBy.Web.Services;
using AutoMapper;
using StandBy.Web.DTOs;
using StandBy.Web.Models;

namespace StandBy.Web.Controllers
{


    public class PedidosController : Controller
    {


        private readonly IPedidosService _pedidosService;
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;


        public PedidosController(IPedidosService pedidosService, IMapper mapper, IClientesService clientesService)
        {
            _pedidosService = pedidosService;
            _clientesService = clientesService;
            _mapper = mapper;
        }






        [Route("lista-de-pedidos")]
        public async Task<IActionResult> Index()
        {

            List<PedidoDTO> pedidos = await _pedidosService.ObterTodos();

            return View(pedidos);


        }







        [HttpGet("novo-pedido")]
        public async Task<IActionResult> Create()
        {

            IEnumerable<ClienteDTO> clientes = await _pedidosService.BuscarListaDeCliente();
            PedidoDTO pedido = new PedidoDTO();
            pedido.ListaDeCliente = clientes;


            return View(pedido);

        }

        [HttpPost("novo-pedido")]
        public async Task<IActionResult> Create(PedidoDTO pedidoDTO)
        {
            if (!ModelState.IsValid) return View(pedidoDTO);

            Pedido abrirPedido = new Pedido();
            abrirPedido.ClienteId = pedidoDTO.ClienteId;
            abrirPedido.Status = Char.Parse("A");
            abrirPedido.Valor = 0.0M;





            await _pedidosService.Adicionar(_mapper.Map<Pedido>(abrirPedido));
            return RedirectToAction("Index", "Pedidos");

        }



        [HttpGet("editar-pedidos/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await _pedidosService.ObterPorId(id);
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

            var pedidoAtualizacao = await _pedidosService.ObterPorId(id);

            pedidoAtualizacao.Status = pedido.Status;



            if (!ModelState.IsValid) return View(pedido);

            await _pedidosService.Atualizar(id, pedidoAtualizacao);



            return RedirectToAction("Index");

        }

        [HttpGet("excluir-pedido/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _pedidosService.ObterPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);

        }



        [HttpPost("excluir-produto/{id:int}")]
        public async Task<IActionResult> Delete(int id, PedidoDTO pedidoDTO)
        {

            var test = id;

            await _pedidosService.Remover(id);

            TempData["Sucesso"] = "Pedio excluido com sucesso!";
            return RedirectToAction("Index");

        }


    }
}
