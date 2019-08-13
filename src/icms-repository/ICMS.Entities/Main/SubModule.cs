using System;
using System.Collections.Generic;
using System.Text;
using ICMS.Entities.Base;

namespace ICMS.Entities.Main
{
    public class SubModule : BaseEntity<int>
    {
        public int moduleId { get; set; }

        public string name { get; set; }

        public string display { get; set; }

        public string description { get; set; }

        public bool isEnabled { get; set; }

        public string url { get; set; }

        public int order { get; set; }

        public string roles { get; set; }

        public virtual Module module { get; set; }
    }
}
