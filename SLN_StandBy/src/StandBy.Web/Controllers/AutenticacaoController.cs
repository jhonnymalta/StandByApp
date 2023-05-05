using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StandBy.Web.DTOs;
using StandBy.Web.Services;

namespace StandBy.Web.Controllers
{

    public class AutenticacaoController : Controller
    {


        private readonly IAutenticacaoService _autenticationService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticationService = autenticacaoService;
        }



        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);
            var resposta = await _autenticationService.Registro(usuarioRegistro);
            if (false) return View(usuarioRegistro);

            return RedirectToAction("Index", "Produtos");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            var resposta = await _autenticationService.Login(usuarioLogin);

            if (false) return View(usuarioLogin);

            return RedirectToAction("Index", "Produtos");


        }
        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login", "Autenticacao");
        }

    }
}