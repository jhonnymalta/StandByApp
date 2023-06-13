using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Api.DTOs;

namespace StandyBy.Api.Controllers
{
    [Route("api/pedidos")]

    public class PedidosController : MainController
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoServices _pedidoServices;
        private readonly IMapper _mapper;
        public PedidosController(IPedidoRepository pedidoRepository, IMapper mapper, IPedidoServices pedidoServices)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _pedidoServices = pedidoServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoDTO>> ObterTodos()
        {
            var pedidos = _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterTodos());

            return pedidos;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoDTO>> ObterPorId(int id)
        {
            var pedido = _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterPorId(id));

            if (pedido == null) return NotFound();
            return Ok(pedido);

        }
        [HttpGet("cliente/{id:int}")]
        public async Task<ActionResult<PedidoDTO>> ObterPorCliente(int id)
        {
            var pedido = _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterUmPedidoPorCliente(id));

            if (pedido == null) return NotFound();
            return Ok(pedido);

        }

        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> Adicionar([FromBody] PedidoDTO pedidoDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            var result = await _pedidoServices.Adicionar(pedido);
            if (!result) return BadRequest();

            return Ok(pedido);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PedidoDTO>> Atualizar([FromRoute] int id, [FromBody] PedidoDTO pedidoDTO)
        {
           

            if (!ModelState.IsValid) return BadRequest();

            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            var result = await _pedidoServices.Atualizar(pedido);
            if (!result) return BadRequest();

            return Ok(pedido);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PedidoDTO>> Excluir([FromRoute] int id)
        {
            var pedido = _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterPorId(id));
            if (pedido == null) return NotFound();

            var result = await _pedidoServices.Remover(id);
            if (!result) return BadRequest();

            return Ok(pedido);

        }
    }
}
