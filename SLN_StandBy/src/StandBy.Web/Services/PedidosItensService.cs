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
    public class PedidosItensService : IPedidosItensService
    {


        private readonly HttpClient _httpClient;

        public PedidosItensService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Adicionar(PedidoItemDTO pedidoItem)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(pedidoItem),
                 Encoding.UTF8,
                 mediaType: "application/json"
             );
            JsonSerializer.Serialize(content);


            var response = await _httpClient.PostAsync($"pedidos-itens", content);
            return await response.Content.ReadAsStringAsync();

        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task<PedidoItemDTO> PegarPedidoPorId(int id)
        {
            var response = await _httpClient.GetAsync($"pedidos-itens/ObterItem/{id}");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<PedidoItemDTO>(str);

            return retorno;
        }

        public async Task<IEnumerable<PedidoItemDTO>> PegarTodosItemDePedido(int id)
        {

            var response = await _httpClient.GetAsync($"pedidos-itens/{id}");
            var str = await response.Content.ReadAsStringAsync();
            var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PedidoItemDTO>>(str);

            return retorno;
        }



        public async Task<string> Remover(int id)
        {
            var response = await _httpClient.DeleteAsync($"pedidos-itens/{id}");
            var str = await response.Content.ReadAsStringAsync();

            return str;
        }



        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}