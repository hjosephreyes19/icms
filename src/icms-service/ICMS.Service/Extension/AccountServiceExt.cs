using AutoMapper;
using ICMS.Entities.Main;
using ICMS.Entities.Base;
using ICMS.DTO.Account;
using ICMS.Service.Implementation;

namespace ICMS.Service.Extensions
{
    public static class AccountServiceExt
    {
        public static IMapper GetMapper(this AccountServiceImpl account)
        {
            return (new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, AddAccountDTO>();
                cfg.CreateMap<AddAccountDTO, User>();
            })).CreateMapper();
        }
    }
}
