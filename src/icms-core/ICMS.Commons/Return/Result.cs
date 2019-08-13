using System;
using System.Collections.Generic;
using System.Text;
using static ICMS.Commons.Enum.ICMSEnum;

namespace ICMS.Commons.Return
{
    public class Result
    {
        public string id { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public bool isRedirect { get; set; }
        public string redirectUrl { get; set; }
        public ErrorCode errorCode { get; set; }

        public Result()
        {
            id = "";
            success = false;
            message = "";
            isRedirect = false;
            redirectUrl = "";
            errorCode = ErrorCode.DEFAULT;
        }
    }
}
