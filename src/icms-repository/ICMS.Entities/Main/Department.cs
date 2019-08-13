using Microsoft.AspNetCore.Identity;
using ICMS.Entities.Base;
using System;

namespace ICMS.Entities.Main
{
    public class Department : ExtendedEntity<Guid>
    {
        public string name { set; get; }

        public string description { set; get; }
    }
}
