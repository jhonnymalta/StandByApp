using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using StandBy.Web.DTOs;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StandBy.Web.Services
{
    public class ProdutosServices : IProdutosService
    {





        private readonly HttpClient _httpClient;

        public ProdutosServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public Task Adicionar(ProdutoDTO produtoDTO)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(ProdutoDTO produtoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoDTO>> Buscar(Expression<Func<ProdutoDTO, bool>> predicate)
        {
            throw new NotImplementedException();
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
            JObject result = JObject.Parse(str);



            List<ProdutoDTO> produtos = (List<ProdutoDTO>)JsonConvert.DeserializeObject(result);

            return produtos;
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}