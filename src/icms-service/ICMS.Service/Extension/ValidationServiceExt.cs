using AutoMapper;
using ICMS.Entities.Main;
using ICMS.Entities.Base;
using ICMS.DTO;
using ICMS.Service.Implementation;

namespace ICMS.Service.Extensions
{
    public static class ValidationServiceExt
    {
        public static IMapper GetMapper(this ValidationServiceImpl account)
        {
            return (new MapperConfiguration(cfg =>
            {
            })).CreateMapper();
        }
    }
}
