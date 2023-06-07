using AutoMapper;
using StandBy.Business.Models;
using StandBy.Web.DTOs;

namespace StandBy.Web.AutoMapper.Pedido
{
    public class Pedido : Profile
    {
        public Pedido() { 
        CreateMap<Pedido,PedidoDTO>().ReverseMap();
        CreateMap<PedidoItem, PedidoItemDTO>().ReverseMap();
        }

    }
}
