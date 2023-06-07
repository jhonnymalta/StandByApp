using AutoMapper;
using StandBy.Web.DTOs;

namespace StandBy.Web.AutoMapper.Cliente
{
    public class Cliente : Profile
    {
        public Cliente() { 
        CreateMap<Cliente,ClienteDTO>().ReverseMap();
        }

    }
}
