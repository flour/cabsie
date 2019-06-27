using AutoMapper;
using Cabsie.API.Entities;
using Cabsie.API.Models;

namespace Cabsie.API
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<User, UserVM>();
            CreateMap<User, UserCreateVM>();
        }
    }
}
