using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Text.Json;

using StandBy.Web.DTOs;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace StandBy.Web.Services
{
    public class ProdutosServices : IProdutosService
    {





        private readonly HttpClient _httpClient;

        public ProdutosServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<string> Adicionar(ProdutoDTO produtoDTO)
        {
            var content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(produtoDTO),
                 Encoding.UTF8,
                 mediaType: "application/json"
             );
            System.Text.Json.JsonSerializer.Serialize(content);

            var response = await _httpClient.PostAsync("http://localhost:5109/api/produtos", content);
            return await response.Content.ReadAsStringAsync();

        }

        public Task Atualizar(ProdutoDTO produtoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoDTO>> Buscar(Expression<Func<ProdutoDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public Task<ProdutoDTO> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProdutoDTO>> ObterTodos()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ProdutoDTO>));


            var response = await _httpClient.GetAsync("http://localhost:5109/api/produtos");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<List<ProdutoDTO>>(str);




            return retorno;
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task IProdutosService.Adicionar(ProdutoDTO produtoDTO)
        {
            throw new NotImplementedException();
        }
    }
}