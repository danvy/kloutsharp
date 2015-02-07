// Coded by Alex Danvy
// http://danvy.tv
// http://twitter.com/danvy
// http://github.com/danvy
// Licence Apache 2.0
// Use at your own risk, have fun

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.Lib
{
    public class KloutInfluence
    {
        [JsonProperty("myInfluencers")]
        public List<KloutInfluencer> Influencers { get; set; }
        [JsonProperty("myInfluencees")]
        public List<KloutInfluencer> Influencees { get; set; }
        //public int MyInfluencersCount { get; set; }
        //public int MyInfluenceesCount { get; set; }
    }
}
