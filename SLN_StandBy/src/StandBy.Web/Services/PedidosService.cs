using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Text.Json;

using StandBy.Web.DTOs;
using System.Runtime.Serialization.Json;
using StandBy.Web.Models;

namespace StandBy.Web.Services
{
    public class PedidosService : IPedidosService
    {


        private readonly HttpClient _httpClient;

        public PedidosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }






        public async Task<string> Adicionar(Pedido pedido)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(pedido),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);


            var response = await _httpClient.PostAsync("pedidos", content);
            return await response.Content.ReadAsStringAsync();

        }







        public async Task<string> Atualizar(int id, PedidoDTO pedidoDTO)
        {

            var content = new StringContent(
                JsonSerializer.Serialize(pedidoDTO),
                Encoding.UTF8,
                mediaType: "application/json"
            );
            JsonSerializer.Serialize(content);
            var response = await _httpClient.PutAsync($"pedidos/{id}", content);
            return await response.Content.ReadAsStringAsync();
        }








        public Task<IEnumerable<PedidoDTO>> Buscar(Expression<Func<ProdutoDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }










        public async Task<PedidoDTO> ObterPorId(int id)
        {
            var response = await _httpClient.GetAsync($"pedidos/{id}");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<PedidoDTO>(str);
            return retorno;
        }









        public async Task<List<PedidoDTO>> ObterTodos()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<PedidoDTO>));


            var response = await _httpClient.GetAsync("pedidos");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PedidoDTO>>(str);

            return retorno;
        }







        public async Task<string> Remover(int id)
        {
            var response = await _httpClient.DeleteAsync($"pedidos/{id}");
            var str = await response.Content.ReadAsStringAsync();

            return str;
        }




        public async Task<IEnumerable<ClienteDTO>> BuscarListaDeCliente()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ClienteDTO>));

            var response = await _httpClient.GetAsync("clientes");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ClienteDTO>>(str);

            return retorno;
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