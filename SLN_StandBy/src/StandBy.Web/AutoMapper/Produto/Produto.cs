using AutoMapper;
using StandBy.Web.DTOs;

namespace StandBy.Web.AutoMapper.Produto
{
    public class Produto : Profile
    {
        public Produto() { 
        CreateMap<Produto,ProdutoDTO>().ReverseMap();
        }

    }
}
