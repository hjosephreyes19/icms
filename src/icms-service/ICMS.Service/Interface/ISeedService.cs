using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICMS.Commons.Return;
using ICMS.DTO.Module;

namespace ICMS.Service.Interface
{
    public interface ISeedService
    {
        Task<Result> AddModule(List<AddModuleDTO> dto, string userName);
    }
}
