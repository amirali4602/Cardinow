using AutoMapper;
using Cardinow.DataAccess.DbEntities;
using Cardinow.Domain.DomainEntities;
namespace Cardinow.DataAccess.DbMapping;

public class DbMapper : Profile
{
    public DbMapper()
    {

        CreateMap<UserDbEntity, UserEntity>().ReverseMap();
       
    }
}
