using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICMS.Commons.Return;
using ICMS.DTO.Module;
using Microsoft.Extensions.Logging;
using ICMS.Repositories.Framework.Interface;
using AutoMapper;
using ICMS.Service.Extensions;
using ICMS.Entities.Main;
using System.Linq;
using static ICMS.Commons.Enum.ICMSEnum;
using ICMS.Service.Interface;

namespace ICMS.Service.Implementation
{
    public class SeedServiceImpl : ISeedService
    {
        protected readonly ILogger _logger;
        protected readonly IEFRepository _repo;
        private readonly IMapper _mapper;

        public SeedServiceImpl(ILogger<AccountServiceImpl> logger, IEFRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = this.GetMapper();
        }

        public async Task<Result> AddModule(List<AddModuleDTO> dto, string userName)
        {
            Result result = new Result();
            try
            {
                if (dto.Count > 0)
                {
                    var modules = _mapper.Map<List<Module>>(dto);
                    foreach (var module in modules)
                    {
                        var tempModule = await _repo.GetAsync<Module>(filter: row => row.name == module.name);
                        if (tempModule.Count() == 0)
                        {
                            module.createdBy = userName;
                            module.createdDate = DateTime.UtcNow;

                            _repo.Create(module);
                            await _repo.SaveAsync();
                        }

                        result.success = true;
                        result.message = "Module successfully added.";
                        result.errorCode = ErrorCode.DEFAULT;
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
            return result;
        }
    }
}
