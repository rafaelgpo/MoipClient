using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moip
{


    public class MoipException : Exception
    {
        public string message { get; set; }
        public Error[] errors { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string description { get; set; }
    }

}
