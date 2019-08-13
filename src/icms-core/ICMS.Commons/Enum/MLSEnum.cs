using System;
using System.Collections.Generic;
using System.Text;

namespace ICMS.Commons.Enum
{
    public class ICMSEnum
    {
        public enum ErrorCode
        {
            DEFAULT = 0,
            INVALID_INPUT = 100,
            DATA_NOT_FOUND = 200,
            NO_CHANGE = 300
        }

        public enum Role
        {
            ADMINISTRATOR,
            USER
        }
    }
}
