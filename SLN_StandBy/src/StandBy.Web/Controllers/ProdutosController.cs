using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StandBy.Business.Models;
using StandBy.Web.DTOs;
using StandBy.Web.Models;
using StandBy.Web.Services;

namespace StandBy.Web.Controllers
{

    [Authorize]
    public class ProdutosController : MainController
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







        [HttpGet("novo-produto")]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost("novo-produto")]
        public async Task<IActionResult> Create(ProdutoDTO produtoDTO)
        {

           
            if (!ModelState.IsValid) return View(produtoDTO);

            var resposta = await _produtosService.Adicionar(produtoDTO);

            if (resposta.Contains("false")) {

                ViewBag.Country =  "O código do produto já está cadastrado";
                return View(produtoDTO);
            }
            
           
           
            return RedirectToAction("Index", "Produtos");

        }



        [HttpGet("editar-produto/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtosService.ObterPorId(id);
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

            var produtoAtualizacao = await _produtosService.ObterPorId(id);
            produtoAtualizacao.Descricao = produto.Descricao;
            produtoAtualizacao.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoAtualizacao.Valor = produto.Valor;

            if (!ModelState.IsValid) return View(produto);

            await _produtosService.Atualizar(id, produtoAtualizacao);



            return RedirectToAction("Index");

        }

        [HttpGet("excluir-produto/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtosService.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);

        }



        [HttpPost("excluir-produto/{id:int}")]
        public async Task<IActionResult> Delete(int id, ProdutoDTO produtoDTO)
        {

            var test = id;

            await _produtosService.Remover(id);

            TempData["Sucesso"] = "Produto excluido com sucesso!";
            return RedirectToAction("Index", "Produtos");

        }


    }
}
