using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Text.Json;

using StandBy.Web.DTOs;
using System.Runtime.Serialization.Json;
using Microsoft.Extensions.Options;
using StandBy.Web.Models;

namespace StandBy.Web.Services
{
    public class ProdutosService : Service, IProdutosService
    {





        private readonly HttpClient _httpClient;

        public ProdutosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<string> Adicionar(ProdutoDTO produtoDTO)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(produtoDTO),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);


            var response = await _httpClient.PostAsync("produtos", content);
            if(!response.IsSuccessStatusCode)
            {
                return "false";
            }


            return await response.Content.ReadAsStringAsync();


        }

        public async Task<string> Atualizar(int id, ProdutoDTO produtoDTO)
        {

            var content = new StringContent(
                JsonSerializer.Serialize(produtoDTO),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);
            var response = await _httpClient.PutAsync($"produtos/{id}", content);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<IEnumerable<ProdutoDTO>> Buscar(Expression<Func<ProdutoDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }




        public async Task<ProdutoDTO> ObterPorId(int id)
        {
            var response = await _httpClient.GetAsync($"produtos/{id}");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<ProdutoDTO>(str);
            return retorno;
        }

        public async Task<List<ProdutoDTO>> ObterTodos()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ProdutoDTO>));


            var response = await _httpClient.GetAsync("produtos");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProdutoDTO>>(str);

            return retorno;
        }

        public async Task<string> Remover(int id)
        {
            var response = await _httpClient.DeleteAsync($"produtos/{id}");
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