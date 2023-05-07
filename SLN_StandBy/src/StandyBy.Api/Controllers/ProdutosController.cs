using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandyBy.Api.DTOs;

namespace StandyBy.Api.Controllers
{
    [Route("api/produtos")]

    public class ProdutosController : MainController
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper, IProdutoServices produtoServices)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _produtoServices = produtoServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos());

            return produtos;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(int id)
        {
            var produto = _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));

            if (produto == null) return NotFound();
            return Ok(produto);

        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar([FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var produto = _mapper.Map<Produto>(produtoDTO);
            var result = await _produtoServices.Adicionar(produto);
            if (!result) return BadRequest();

            return Ok(produto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Atualizar([FromRoute] int id, [FromBody] ProdutoDTO produtoDTO)
        {
            //if (id != produtoDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var produto = _mapper.Map<Produto>(produtoDTO);
            var result = await _produtoServices.Atualizar(produto);
            if (!result) return BadRequest();

            return Ok(produto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Excluir([FromRoute] int id)
        {
            var produto = _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
            if (produto == null) return NotFound();

            var result = await _produtoServices.Remover(id);
            if (!result) return BadRequest();

            return Ok(produto);

        }
    }
}
