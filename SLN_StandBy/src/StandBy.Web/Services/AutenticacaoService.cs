using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using StandBy.Web.DTOs;

namespace StandBy.Web.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {

        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        //Login User
        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(usuarioLogin),
                 Encoding.UTF8,
                 mediaType: "application/json"
             );

            var response = await _httpClient.PostAsync("http://localhost:5109/api/entrar", content);


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }





        //Register New User
        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {

            var content = new StringContent(
                JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);

            var response = await _httpClient.PostAsync("http://localhost:5109/api/nova-conta", content);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());



        }





    }
}