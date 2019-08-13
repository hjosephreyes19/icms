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
using ICMS.DTO.Account;
using ICMS.Entities.Main;

namespace ICMS.Service.Implementation
{
    public class AccountServiceImpl : IAccountService
    {
        protected readonly ILogger _logger;
        protected readonly IEFRepository _repo;
        private readonly IMapper _mapper;
        private readonly IQueryService _queryService;
        private readonly IValidationService _validationService;

        public AccountServiceImpl(ILogger<AccountServiceImpl> logger, IEFRepository repo, IQueryService queryService, IValidationService validationService)
        {
            _logger = logger;
            _repo = repo;
            _queryService = queryService;
            _validationService = validationService;
            _mapper = this.GetMapper();
        }

        public async Task<Result> CreateUser(CreateAccountDTO dto, String createdBy)
        {
            Result result = new Result();
            try
            {
                
                User user = new User
                {
                    firstName = dto.firstName,
                    lastName = dto.lastName,

                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error calling GetTaggedFieldIds: {0}", e.Message);
                throw;
            }
            return result;
        }
    }
}
