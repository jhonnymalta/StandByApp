using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StandBy.Web.DTOs;
using StandBy.Web.Services;

namespace StandBy.Web.Controllers
{


    public class ProdutosController : Controller
    {


        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }






        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {

            List<ProdutoDTO> produtos = await _produtosService.ObterTodos();

            return View(produtos);


        }







        [Route("novo-produto")]
        public async Task<IActionResult> Create(ProdutoDTO produtoDTO)
        {
            // if (!ModelState.IsValid) return View(produtoDTO);
            // var produto = _mapper.Map<Produto>(produtoDTO);
            // await _produtoServices.Adicionar(produto);
            return RedirectToAction("Index");

        }



        [Route("editar-produto/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            // var produto = _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));

            // if (produto == null)
            // {
            //     return NotFound();
            // }

            // return View(produto);

            return Ok();
        }



        [Route("editar-produto/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProdutoDTO produto)
        {
            // if (id != produto.Id) return NotFound();

            // var produtoAtualizacao = await _produtoRepository.ObterPorId(id);
            // produtoAtualizacao.Descricao = produto.Descricao;
            // produtoAtualizacao.QuantidadeEstoque = produto.QuantidadeEstoque;
            // produtoAtualizacao.Valor = produto.Valor;

            // if (!ModelState.IsValid) return View(produto);

            // await _produtoServices.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            // if (!OperacaoValida()) return View(produto);

            // return RedirectToAction("Index");
            return Ok();
        }

        [Route("excluir-produto/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // var produto = await _produtoRepository.ObterPorId(id);

            // if (produto == null)
            // {
            //     return NotFound();
            // }

            // return View(_mapper.Map<ProdutoDTO>(produto));
            return Ok();
        }



        [Route("excluir-produto/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            // var produto = await _produtoRepository.ObterPorId(id);

            // if (produto == null)
            // {
            //     return NotFound();
            // }

            // await _produtoServices.Remover(produto.Id);

            // if (!OperacaoValida()) return View(produto);

            // TempData["Sucesso"] = "Produto excluido com sucesso!";

            // return RedirectToAction("Index");
            return Ok();
        }


    }
}
