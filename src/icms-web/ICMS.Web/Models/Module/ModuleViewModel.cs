using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICMS.Web.Models.Module
{
    public class ModuleViewModel
    {
        public string name { get; set; }

        public string description { get; set; }

        public bool isEnabled { get; set; }

        public string url { get; set; }

        public int order { get; set; }
    }
}
