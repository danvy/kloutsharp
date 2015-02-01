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
