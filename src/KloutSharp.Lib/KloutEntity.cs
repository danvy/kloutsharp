using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.Lib
{
    public class KloutEntity
    {
        public string Id { get; set; }
        public KloutUser Payload { get; set; }
    }
}
