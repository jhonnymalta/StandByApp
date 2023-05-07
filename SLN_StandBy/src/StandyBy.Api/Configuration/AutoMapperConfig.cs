using StandBy.Business.Models;
using StandyBy.Api.DTOs;

using AutoMapper;

namespace StandyBy.Api.Extensions
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
            CreateMap<PedidoItemDTO, PedidoItem>().ReverseMap();
        }
    }
}
