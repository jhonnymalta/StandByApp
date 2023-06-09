using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Api.DTOs;

namespace StandyBy.Api.Controllers
{
    [Route("api/clientes")]

    public class ClientesController : MainController
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteServices _clienteServices;
        private readonly IMapper _mapper;
        public ClientesController(IClienteRepository clienteRepository, IMapper mapper, IClienteServices clienteServices)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _clienteServices = clienteServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDTO>> ObterTodos()
        {
            var clientes = _mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos());

            return clientes;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> ObterPorId(int id)
        {
            var cliente = _mapper.Map<ClienteDTO>(await _clienteRepository.ObterPorId(id));

            if (cliente == null) return NotFound();
            return Ok(cliente);

        }




        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Adicionar([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var result = await _clienteServices.Adicionar(cliente);
            if (!result) return BadRequest();

            return CustomResponse(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Atualizar([FromRoute] int id, [FromBody] ClienteDTO clienteDTO)
        {
            //if (id != produtoDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            bool result = await _clienteServices.Atualizar(cliente);
            if (!result) return BadRequest();

            return Ok(cliente);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Excluir([FromRoute] int id)
        {
            var cliente = _mapper.Map<ClienteDTO>(await _clienteRepository.ObterPorId(id));
            if (cliente == null) return NotFound();

            var result = await _clienteServices.Remover(id);
            if (!result) return BadRequest();

            return Ok(cliente);

        }
    }
}
