using AutoMapper;
using ICMS.Entities;
using ICMS.DTO.Module;
using ICMS.Entities.Main;
using ICMS.Service.Implementation;

namespace ICMS.Service.Extensions
{
    public static class SeedServiceExt
    {
        public static IMapper GetMapper(this SeedServiceImpl account)
        {
            return (new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddModuleDTO, Module>();
                cfg.CreateMap<Module, AddModuleDTO>();
                cfg.CreateMap<AddSubModuleDTO, SubModule>();
                cfg.CreateMap<SubModule, AddSubModuleDTO>();
            })).CreateMapper();
        }
    }
}
