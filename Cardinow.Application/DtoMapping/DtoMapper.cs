using AutoMapper;
using Cardinow.DataAccess.DbEntities;
using Cardinow.Application.Dtos;
using Cardinow.Domain.DomainEntities;
namespace Cardinow.Application.DtoMapping;

public class DtoMapper : Profile
{
    public DtoMapper()
    {
        CreateMap<UserEntity, UserDto>().ReverseMap();
        CreateMap<UserEntity, CreateUserDto>().ReverseMap();
        CreateMap<UserEntity, UpdateUserDto>().ReverseMap();

    }
}
