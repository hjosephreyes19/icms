using System;
using System.Collections.Generic;
using System.Text;
using ICMS.Entities;

namespace ICMS.DTO.Module
{
    public class ReadModuleDTO
    {
        public string id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool isEnabled { get; set; }

        public string url { get; set; }

        public int order { get; set; }

        public string role { get; set; }

        public List<AddSubModuleDTO> subModule { get; set; }
    }
}
