using System;
using System.Collections.Generic;
using System.Text;

namespace ICMS.DTO.Account
{
    public class CreateAccountDTO
    {
        public string userName { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
