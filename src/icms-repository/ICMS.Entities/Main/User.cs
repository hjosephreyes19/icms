using Microsoft.AspNetCore.Identity;
using ICMS.Entities.Base;

namespace ICMS.Entities.Main
{
    public class User : IdentityUser<int>, IEntity
    {
        public string firstName { set; get; }

        public string lastName { set; get; }

        public string department { set; get; }

        public string createdBy { set; get; }
    }
}
