using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICMS.Commons.Return;
using ICMS.DTO.Module;

namespace ICMS.Service.Interface
{
    public interface IQueryService
    {
        Task<List<ReadModuleDTO>> ReadModule(string role);
    }
}
