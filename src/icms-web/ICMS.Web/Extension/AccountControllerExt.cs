using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICMS.Web.Controllers;

namespace ICMS.Web.Extension
{
    public static class AccountControllerExt
    {
        public static IMapper GetMapper(this AccountController account)
        {
            return (new MapperConfiguration(cfg =>
             {

             })).CreateMapper();
        }
    }
}
