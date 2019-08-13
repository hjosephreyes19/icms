using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICMS.Commons.Return;
using ICMS.DTO.Account;

namespace ICMS.Service.Interface
{
    public interface IAccountService
    {
        Task<Result> CreateUser(CreateAccountDTO dto, String createdBy);
    }
}
