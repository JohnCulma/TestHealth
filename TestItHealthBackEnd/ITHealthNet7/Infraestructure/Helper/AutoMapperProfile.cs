using AutoMapper;
using Domain;
using Presentation.UserDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructure.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patients, CreateUserDto>().ReverseMap();
            CreateMap<Patients, UpdateDto>().ReverseMap();
            
        }
    }
}

