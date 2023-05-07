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


            var response = await _httpClient.PostAsync("http://localhost:5109/api/produtos", content);
            return await response.Content.ReadAsStringAsync();

        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public Task<string> Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}