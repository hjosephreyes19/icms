using AutoMapper;
using ICMS.Entities.Main;
using ICMS.Entities.Base;
using ICMS.DTO;
using ICMS.Service.Implementation;
using ICMS.DTO.Module;

namespace ICMS.Service.Extensions
{
    public static class QueryServiceEx
    {
        public static IMapper GetMapper(this QueryServiceImpl account)
        {
            return (new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReadModuleDTO, Module>();
                cfg.CreateMap<Module, ReadModuleDTO>();
            })).CreateMapper();
        }
    }
}
