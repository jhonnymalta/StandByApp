using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;
using StandBy.Business.Services;
using StandBy.Web.DTOs;

namespace StandBy.Web.Controllers
{
    
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;
        

        public ProdutosController(IProdutoRepository produtoRepository,IMapper mapper,IProdutoServices produtoServices,INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoServices= produtoServices;
            _mapper = mapper;

        }

        
        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos()));

        }



        [Route("novo-produto")]
        public async Task<IActionResult> Create(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return View(produtoDTO);
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoServices.Adicionar(produto);
            return RedirectToAction("Index");

        }



        [Route("editar-produto/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }



        [Route("editar-produto/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProdutoDTO produto)
        {
            if (id != produto.Id) return NotFound();

            var produtoAtualizacao = await _produtoRepository.ObterPorId(id);
            produtoAtualizacao.Descricao = produto.Descricao;
            produtoAtualizacao.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoAtualizacao.Valor = produto.Valor;

            if (!ModelState.IsValid) return View(produto); 

            await _produtoServices.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            if (!OperacaoValida()) return View(produto);

            return RedirectToAction("Index");
        }

        [Route("excluir-produto/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProdutoDTO>(produto));
        }



        [Route("excluir-produto/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var produto = await  _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _produtoServices.Remover(produto.Id);

            if (!OperacaoValida()) return View(produto);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }


    }
}
