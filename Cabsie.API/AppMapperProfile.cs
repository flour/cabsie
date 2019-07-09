using AutoMapper;
using Cabsie.API.Models;
using Cabsie.API.ViewModels;

namespace Cabsie.API
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<User, UserVM>();
            CreateMap<User, UserCreateVM>();
            CreateMap<RegisterVM, User>();
        }
    }
}
