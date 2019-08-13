using System;
using System.Collections.Generic;
using System.Text;
using ICMS.Entities;

namespace ICMS.DTO.Module
{
    public class AddModuleDTO
    {
        public string name { get; set; }

        public string display { get; set; }

        public string description { get; set; }

        public bool isEnabled { get; set; }

        public string url { get; set; }

        public int order { get; set; }

        public string roles { get; set; }

        public List<AddSubModuleDTO> subModule { get; set; }
    }
}
