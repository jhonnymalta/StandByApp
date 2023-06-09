using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Text.Json;

using StandBy.Web.DTOs;
using System.Runtime.Serialization.Json;


namespace StandBy.Web.Services
{
    public class ClientesService : IClientesService
    {





        private readonly HttpClient _httpClient;

        public ClientesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<string> Adicionar(ClienteDTO clienteDTO)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(clienteDTO),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);


            var response = await _httpClient.PostAsync("clientes", content);

            if (!response.IsSuccessStatusCode)
            {
                return "false";
            }
            return await response.Content.ReadAsStringAsync();

        }

        public async Task<string> Atualizar(int id, ClienteDTO clienteDTO)
        {

            var content = new StringContent(
                JsonSerializer.Serialize(clienteDTO),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);
            var response = await _httpClient.PutAsync($"clientes/{id}", content);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<IEnumerable<ClienteDTO>> Buscar(Expression<Func<ClienteDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }




        public async Task<ClienteDTO> ObterPorId(int id)
        {
            var response = await _httpClient.GetAsync($"clientes/{id}");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteDTO>(str);
            return retorno;
        }

        public async Task<List<ClienteDTO>> ObterTodos()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ClienteDTO>));


            var response = await _httpClient.GetAsync("clientes");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClienteDTO>>(str);

            return retorno;
        }

        public async Task<string> Remover(int id)
        {
            var response = await _httpClient.DeleteAsync($"clientes/{id}");
            var str = await response.Content.ReadAsStringAsync();

            return str;
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }


    }
}