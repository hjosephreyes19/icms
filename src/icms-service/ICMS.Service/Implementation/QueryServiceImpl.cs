using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ICMS.Repositories.Framework.Interface;
using AutoMapper;
using ICMS.Service.Extensions;
using ICMS.Service.Interface;
using ICMS.Commons.Return;
using ICMS.DTO.Module;
using ICMS.Entities.Main;

namespace ICMS.Service.Implementation
{
    public class QueryServiceImpl : IQueryService
    {
        protected readonly ILogger logger;
        protected readonly IEFRepository repo;
        private readonly IMapper mapper;
        private readonly IValidationService validationService;

        public QueryServiceImpl(ILogger<AccountServiceImpl> logger, IEFRepository repo, IValidationService validationService)
        {
            this.logger = logger;
            this.repo = repo;
            this.validationService = validationService;
            this.mapper = this.GetMapper();
        }

        public async Task<List<ReadModuleDTO>> ReadModule(string role)
        {
            List<ReadModuleDTO> myReturn = new List<ReadModuleDTO>();
            var listOfModule = await repo.GetAsync<Module>
                (
                    filter: c => c.isEnabled == true && c.roles.Contains(role),
                    include: source => source.Include(c => c.subModule)
                );

            myReturn = mapper.Map<List<ReadModuleDTO>>(listOfModule);

            return myReturn;
        }
    }
}
