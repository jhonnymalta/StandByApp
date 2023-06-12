using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StandBy.Web.DTOs;
using StandBy.Web.Services;


namespace StandBy.Web.Controllers
{

    [Authorize]
    public class ClientesController : Controller
    {


        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }






        [Route("lista-de-clientes")]
        public async Task<IActionResult> Index()
        {

            List<ClienteDTO> clientes = await _clientesService.ObterTodos();

            return View(clientes);


        }







        [HttpGet("novo-cliente")]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost("novo-cliente")]
        public async Task<ActionResult> Create(ClienteDTO clienteDTO)
        {
           var cpfFormater = clienteDTO.CpfCnpj.Replace(".", "");
            var cpfFormater2 = cpfFormater.Replace("/", "");
            var cpfFormater3 = cpfFormater2.Replace("-", "");
            clienteDTO.CpfCnpj = cpfFormater3;
            if (!ModelState.IsValid) return View(clienteDTO);

            var resposta = await _clientesService.Adicionar(clienteDTO);
            if (resposta.Contains("false"))
            {

                ViewBag.Country = "Este documento já está cadastrado.";
                return View(clienteDTO);
            }
            return RedirectToAction("Index", "clientes");

        }



        [HttpGet("editar-cliente/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clientesService.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();

            }
            return View(cliente);


        }



        [Route("editar-cliente/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id) return NotFound();

            var clienteAtualizacao = await _clientesService.ObterPorId(id);
            clienteAtualizacao.CpfCnpj = cliente.CpfCnpj;
            clienteAtualizacao.Ativo = cliente.Ativo;
            clienteAtualizacao.Nome = cliente.Nome;


            if (!ModelState.IsValid) return View(cliente);

            await _clientesService.Atualizar(id, clienteAtualizacao);



            return RedirectToAction("Index");

        }

        [HttpGet("excluir-cliente/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _clientesService.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);

        }



        [HttpPost("excluir-cliente/{id:int}")]
        public async Task<IActionResult> Delete(int id, ProdutoDTO produtoDTO)
        {

            var test = id;

            await _clientesService.Remover(id);

            TempData["Sucesso"] = "Produto excluido com sucesso!";
            return RedirectToAction("Index");

        }


    }
}
