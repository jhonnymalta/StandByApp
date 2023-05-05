using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StandBy.Business.Intefaces;
using StandBy.Business.Models;

namespace StandyBy.Api.Controllers
{
    [Route("api")]
    public class AuthenticationController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationController(IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(
                [FromBody] UsuarioRegistro registerUser
            )
        {

            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(registerUser);
            }


            return Ok(registerUser);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login([FromBody] UsuarioLogin loginUser)
        {
            if (!ModelState.IsValid) return BadRequest();

            var resullt = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, isPersistent: false, lockoutOnFailure: true);

            if (resullt.Succeeded) return Ok(loginUser);

            if (resullt.IsLockedOut)
            {
                return BadRequest("Usuário bloqueado");
            }
            return Ok(loginUser);

        }

    }
}