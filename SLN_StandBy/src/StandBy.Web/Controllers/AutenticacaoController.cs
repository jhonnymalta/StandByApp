using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

           

            UsuarioLogin usuarioLogin = new UsuarioLogin();
            usuarioLogin.Email = usuarioRegistro.Email;
            usuarioLogin.Password = usuarioRegistro.Password;

            
            var resposta2 = await _autenticationService.Login(usuarioLogin);

            if (resposta2.UsuarioToken != null)
            {
                await RealizarLogin(resposta2);
                return RedirectToAction("Index", "Produtos");

            }

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

            if (resposta.UsuarioToken is null || resposta.AcessToken == "") return RedirectToAction("Login");

            await RealizarLogin(resposta);

            return RedirectToAction("Index", "Produtos");


        }

        [HttpPost("sair")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Autenticacao");
        }

        //Realizar Login
        private async Task RealizarLogin(UsuarioRespostaLogin respostaLogin)
        {

            var token = ObterTokenFormatado(respostaLogin.AcessToken);
            var claims = new List<Claim>();
            claims.Add(new Claim(type: "JWT", value: respostaLogin.AcessToken));
            claims.AddRange(token.Claims);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20),
                IsPersistent = true
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }

    }
}