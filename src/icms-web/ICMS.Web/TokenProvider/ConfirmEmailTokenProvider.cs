
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ICMS.Web.TokenProvider
{
    public class ConfirmEmailTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public ConfirmEmailTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<ConfirmEmailTokenProviderOption> options) : base(dataProtectionProvider, options)
        {
        }
    }

    public class ConfirmEmailTokenProviderOption : DataProtectionTokenProviderOptions { }
}