using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StandBy.Web.DTOs;

namespace StandBy.Web.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);
        Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }
}