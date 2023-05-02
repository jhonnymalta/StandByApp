using AutoMapper;
using StandBy.Business.Models;
using StandBy.Web.DTOs;

namespace StandBy.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
