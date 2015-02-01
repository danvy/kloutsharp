using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.Lib
{
    public class KloutException : Exception
    {
        public KloutException()
        {
        }
        public KloutException(string message) : base(message)
        {
        }
        public KloutException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; internal set; }
    }
}
