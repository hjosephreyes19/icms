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

namespace ICMS.Service.Implementation
{
    public class ValidationServiceImpl : IValidationService
    {
        protected readonly ILogger _logger;
        protected readonly IEFRepository _repo;
        private readonly IMapper _mapper;

        public ValidationServiceImpl(ILogger<AccountServiceImpl> logger, IEFRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = this.GetMapper();
        }
    }
}
