using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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


        public async Task<string> Login(UsuarioLogin usuarioLogin)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(usuarioLogin),
                 Encoding.UTF8,
                 mediaType: "application/json"
             );
            JsonSerializer.Serialize(content);

            var response = await _httpClient.PostAsync("http://localhost:5109/api/entrar", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {

            var content = new StringContent(
                JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);



            var response = await _httpClient.PostAsync("http://localhost:5109/api/nova-conta", content);

            return await response.Content.ReadAsStringAsync();



        }
    }
}