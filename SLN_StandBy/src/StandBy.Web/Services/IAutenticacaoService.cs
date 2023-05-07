using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StandBy.Web.DTOs;

namespace StandBy.Web.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}