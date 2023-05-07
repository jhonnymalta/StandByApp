using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Api.DTOs;

namespace StandyBy.Api.Controllers
{
    [Route("api/pedidos-itens")]

    public class PedidosItensController : MainController
    {

        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoItemServices _pedidoItemServices;
        private readonly IMapper _mapper;
        public PedidosItensController(IPedidoItemRepository pedidoItemRepository, IMapper mapper, IPedidoItemServices pedidoItemServices)
        {
            _pedidoItemRepository = pedidoItemRepository;
            _mapper = mapper;
            _pedidoItemServices = pedidoItemServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoItemDTO>> ObterTodos()
        {
            var pedidosItem = _mapper.Map<IEnumerable<PedidoItemDTO>>(await _pedidoItemRepository.ObterTodos());

            return pedidosItem;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoItemDTO>> ObterPorId(int id)
        {
            var pedidoItem = _mapper.Map<PedidoItemDTO>(await _pedidoItemRepository.ObterPorId(id));

            if (pedidoItem == null) return NotFound();
            return Ok(pedidoItem);

        }

        [HttpPost]
        public async Task<ActionResult<PedidoItemDTO>> Adicionar([FromBody] PedidoItemDTO pedidoItemDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var pedidoItem = _mapper.Map<PedidoItem>(pedidoItemDTO);
            var result = await _pedidoItemServices.Adicionar(pedidoItem);
            if (!result) return BadRequest();

            return Ok(pedidoItem);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PedidoItemDTO>> Atualizar([FromRoute] int id, [FromBody] PedidoItemDTO pedidoDTO)
        {
            //if (id != produtoDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var pedidoItem = _mapper.Map<PedidoItem>(pedidoDTO);
            var result = await _pedidoItemServices.Atualizar(pedidoItem);
            if (!result) return BadRequest();

            return Ok(pedidoItem);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PedidoItemDTO>> Excluir([FromRoute] int id)
        {
            var pedidoItem = _mapper.Map<PedidoItemDTO>(await _pedidoItemRepository.ObterPorId(id));
            if (pedidoItem == null) return NotFound();

            var result = await _pedidoItemServices.Remover(id);
            if (!result) return BadRequest();

            return Ok(pedidoItem);

        }
    }
}
