using AutoMapper;
using Cardinow.Application.Dtos.Logs;
using Cardinow.Application.Dtos.Orders;
using Cardinow.Application.Dtos.Payment;
using Cardinow.Application.Dtos.Products;
using Cardinow.Application.Dtos.Profiles;
using Cardinow.Application.Dtos.Resellers;
using Cardinow.Application.Dtos.Users;
using Cardinow.Application.Dtos.Wallets;
using Cardinow.Domain.Entities;
namespace Cardinow.Application.DtoMapping;

public class DtoMapper : AutoMapper.Profile
{
    public DtoMapper()
    {

        #region Product

        CreateMap<Product, ProductReadDto>();

        CreateMap<CreateProductDto, Product>();

        CreateMap<UpdateProductDto, Product>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));
        #endregion
        #region Order

        CreateMap<Order, OrderReadDto>();

        CreateMap<CreateOrderDto, Order>();

        CreateMap<UpdateOrderStatusDto, Order>();

        #endregion

        #region Payment

        CreateMap<Payment, PaymentReadDto>();

        #endregion

        #region Profile

        CreateMap<Domain.Entities.Profile, ProfileReadDto>();

        CreateMap<UpdateProfileDto, Domain.Entities.Profile>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));

        #endregion

        #region Reseller

        CreateMap<Reseller, ResellerReadDto>();

        CreateMap<UpdateCommissionDto, Reseller>();

        CreateMap<UpdateResellerDomainDto, Reseller>();

        #endregion

        #region Wallet

        CreateMap<Wallet, WalletReadDto>();

        CreateMap<WalletTransaction, WalletTransactionDto>();

        #endregion

        #region User

        CreateMap<User, UserAdminReadDto>();
        CreateMap<UpdateUserRoleDto, User>(); 
        CreateMap<RegisterUserDto, User>(); 

        #endregion

        #region Log

        CreateMap<Log, LogReadDto>().ReverseMap();

        #endregion

    }
}
