using AutoMapper;

using AluraControleUsuarioAPI.Data.Dtos;
using AluraControleUsuarioAPI.Models;

namespace AluraControleUsuarioAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
